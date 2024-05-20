using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable
{
    public int health;

    public GameObject gameObject;

    public void Start()
    {
        health = 100;
    }
    public override void Interact(int value = 0)
    {
        if(health > 0)
        {
            health -= value;
            if (health <= 0) 
                Destroy(gameObject);
            Debug.Log("Enemy's health = " +  health);
        }
        else
        {
            Debug.Log("Enemy has died.");
        }
    }
}
