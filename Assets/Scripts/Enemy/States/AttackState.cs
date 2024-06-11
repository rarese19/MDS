using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float originalSpeed;
    private float shotTimer;
    public override void Enter()
    {
        animator = enemy.GetComponent<Animator>();

        originalSpeed = enemy.Agent.speed;
        enemy.Agent.speed = 0;

        animator.SetBool("isIdle", false);
        animator.SetBool("isRunning", false);
    }

    public override void Exit()
    {
        enemy.Agent.speed = originalSpeed;

        animator.SetBool("isIdle", false);
        animator.SetBool("isRunning", false);
    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isRunning", false);
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shotTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);
            if (shotTimer > enemy.fireRate)
            {
                Shoot();
            }
            if (moveTimer > Random.Range(3, 7)) 
            {
                moveTimer = 0;
            }
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > 8)
            {
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }

    public void Shoot()
    {
        Transform gunBarrel = enemy.gunBarrel;
        if (gunBarrel == null)
        {
            Debug.LogError("GunBarrel is not assigned!");
            return;
        }
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, gunBarrel.position, enemy.transform.rotation);
        Vector3 shootDirection = (enemy.Player.transform.position - gunBarrel.transform.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f, 3f), Vector3.up) * shootDirection * 40;
        shotTimer = 0;
        Debug.Log("Shoot");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
