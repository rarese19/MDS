using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;
    public PatrolState patrolState;

    public void Initialise()
    {
        patrolState = new PatrolState();
        ChangeState(patrolState);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeState != null)
        {
            activeState.Perform();
        }
    }

    public void ChangeState(BaseState state)
    {
        if (activeState != null) 
        {
            // run cleanup on activeState
            activeState.Exit();
        }
        // change to a new state
        activeState = state;

        if (activeState != null )
        {
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<EnemyAI>();
            activeState.Enter();
        }
    }
}
