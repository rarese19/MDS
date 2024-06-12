using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    private ObjectiveManager objectiveManager;
    public GameObject gun;

    void Start()
    {
        objectiveManager = GameObject.FindObjectOfType<ObjectiveManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(objectiveManager.getCurrentObjective() == "Get the weapons")
            {
                objectiveManager.CompleteObjective();
                GunInventory gunInventory = other.GetComponent<GunInventory>();

                if (gunInventory != null)
                {
                    gunInventory.AddWeapon("NewGun_semi");
                    gunInventory.AddWeapon("NewGun_auto");
                    Destroy(gameObject); // Destroy the pickup after it has been collected
                    if(gun != null)
                    {
                        Destroy(gun);
                    }
                }
            }
            
        }
    }
}
