using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyBindingScript : MonoBehaviour
{
    public InputActionReference MoveRef, JumpRef;
    void Start()
    {
        
    }

    private void OnEnable() {
        MoveRef.action.Disable();
        JumpRef.action.Disable();
    }

    private void OnDisable(){ 
        MoveRef.action.Enable();
        JumpRef.action.Enable();
    }

    void Update()
    {
        
    }
}
