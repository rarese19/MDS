using UnityEngine;

public abstract class BaseState
{
    // instance of enemy class
    public EnemyAI enemy;
    // instance of statemachine class
    public StateMachine stateMachine;
    public Animator animator;

    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();
}