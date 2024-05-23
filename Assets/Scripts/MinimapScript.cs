using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MinimapScript : MonoBehaviour
{

    public Transform player;
    public float fixedYPosition = 10f;

    void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = fixedYPosition;
        transform.position = newPosition;
    }
}
