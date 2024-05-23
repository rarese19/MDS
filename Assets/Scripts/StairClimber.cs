using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairClimber : MonoBehaviour
{
    public float stairClimbSpeed = 100f;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Stair"))
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                if (Vector3.Angle(contact.normal, Vector3.up) > 45 && Vector3.Angle(contact.normal, Vector3.up) < 135)
                {
                    Vector3 moveDirection = Vector3.up * stairClimbSpeed * Time.deltaTime;
                    transform.position += moveDirection;
                }
            }
        }
    }

}
