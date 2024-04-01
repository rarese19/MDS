using UnityEngine;

public class GunSystem : MonoBehaviour
{
    //Gun stats
    public int damage;
    public float timeBetweenShots, range, reloadTime, cooldownTime;
    public int magazineSize;
    private int bulletsLeft, bulletsShot;

    //For guns like shotguns
    public int bulletsPerTap;

    //Allow gun spray
    public bool allowButtonHold;

    //Players states
    //being only four, I don't see the point of using anything fancier than bool variables.
    private bool singleShooting, sprayShooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCamera;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;// - useful after implementing enemies.



    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void PlayerInput() {
        
        //Should be change to conserv cross-play
        //It's a intermediary solution
        if(allowButtonHold) {
            singleShooting = false;
            sprayShooting = Input.GetKeyDown(KeyCode.Mouse0);
        }
        else {
            singleShooting = Input.GetKey(KeyCode.Mouse0);
            sprayShooting = false;
        }

        //Reload call
        if(Input.GetKey(KeyCode.R) && bulletsLeft < magazineSize && !reloading) {
            Reload();
        }

        //Need to add Single and Spray Shooting
    }

    private void Reload() {

    }


}
