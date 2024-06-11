using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeTrigger : MonoBehaviour
{
    private ObjectiveManager objectiveManager;

    void Start()
    {
        objectiveManager = GameObject.FindObjectOfType<ObjectiveManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(objectiveManager.getCurrentObjective() == "Escape the prison")
            {
                objectiveManager.CompleteObjective();
            }
        }
    }
}

