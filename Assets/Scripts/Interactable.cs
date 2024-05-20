using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // Parent class to all interactable objects
    public string promptMessage;

    //Base and simple Interact contain the value param to ease the work on the enemy combat
    public void BaseInteract(int value = 0)
    {
        Interact(value);
    }

    public virtual void Interact(int value = 0)
    {

    }
}
