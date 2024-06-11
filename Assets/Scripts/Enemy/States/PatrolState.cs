using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public int waypointIndex;
    public float waitTimer;
    public override void Enter()
    {
        animator = enemy.GetComponent<Animator>();
        animator.SetBool("isIdle", false);
        animator.SetBool("isRunning", true);
    }

    public override void Perform()
    {
        PatrolCycle();
        if (enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
    }

    public override void Exit()
    {
        animator.SetBool("isIdle", false);
        animator.SetBool("isRunning", false);
    }

    public void PatrolCycle()
    {
        if (enemy.Agent.remainingDistance < 0.2f)
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isRunning", false);
            waitTimer += Time.deltaTime;
            if (waitTimer > 3)
            {
                if (waypointIndex < enemy.path.wayPoints.Count - 1)
                {
                    waypointIndex++;
                }
                else
                {
                    waypointIndex = 0;
                }
                enemy.Agent.SetDestination(enemy.path.wayPoints[waypointIndex].position);
                waitTimer = 0;
                animator.SetBool("isIdle", false);
                animator.SetBool("isRunning", true);

            }
        }
        else
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isRunning", true);
        }
    }
}
