using System;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    //Gun stats
    public int damage;
    public float timeBetweenShots, range, reloadTime;
    public int magazineSize, bulletsShot;
    private int bulletsLeft, sprayBulletNum;

    //For guns like shotguns
    public int bulletsPerTap;

    //Allow gun spray
    public bool allowButtonHold;

    //Players states
    //being only four, I don't see the point of using anything fancier than bool variables.
    private bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCamera;
    public Transform attackPoint;
    public LayerMask whatIsEnemy;// - useful after implementing enemies.



    void Start()
    {
        fpsCamera = GetComponent<PlayerLook>().cam;
        sprayBulletNum = 0;
        readyToShoot = true;
        Reload();
    }

    void Update()
    {
        PlayerInput();
    }

    private void PlayerInput() {
        
        //Should be change to conserv cross-play
        //It's a intermediary solution
        if(allowButtonHold) {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        //Reload call
        if((Input.GetKey(KeyCode.R) && bulletsLeft < magazineSize && !reloading) || (bulletsLeft == 0 && bulletsShot != 0)) {
            Reload();
        }

        if(shooting && bulletsLeft > 0 && readyToShoot && !reloading)
        {
            Shoot();
        }

    }

    private void Reload() {
        reloading = true;

        Debug.Log("Reloading...");

        int residualBullets = bulletsLeft;

        //Takes the value of magazineSize if there are bullets left to fill another magazine,
        //else takes the rest of bullets.
        bulletsLeft = (bulletsShot > magazineSize) ? magazineSize : bulletsShot;

        bulletsShot += residualBullets;

        //Substract the bullets reloaded.
        if(bulletsShot - magazineSize < 0)
        {
            bulletsShot = 0;
        }
        else
        {
            bulletsShot -= magazineSize;
        }

        Invoke("ReloadCooldown", reloadTime);
    }

    private void ReloadCooldown()
    {
        reloading = false;
        Debug.Log("Ready to shoot!");
    }

    private void Shoot()
    {
        //Create a ray at the center of the view model
        Ray ray = new Ray(fpsCamera.transform.position, fpsCamera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * range);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, range, whatIsEnemy))
        {
            if(hitInfo.collider.GetComponent<Enemy>() != null)
            {
                hitInfo.collider.GetComponent<Enemy>().BaseInteract(damage);
            }
        }

        readyToShoot = false;

        bulletsLeft--;
        sprayBulletNum++;
        //Debug.Log("S-a tras " + sprayBulletNum);
        Debug.Log("Bullets left: " + bulletsLeft + "/" + bulletsShot);


        Invoke("ReadyToShoot", timeBetweenShots);
        
    }

    private void ReadyToShoot()
    {
        readyToShoot = true;
        if(!shooting)
        {
            sprayBulletNum = 0;
        }
    }


}
