using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    //CurrentState
    private State currentState;
    public string currentStateName {get; private set;}

    //Update, LateUpdate, FixedUpdate
    public void Update()
    {
        currentState?.Update();
    }
    public void LateUpdate()
    {
        currentState?.LateUpdate();
    }
    public void FixedUpdate()
    {
        currentState?.FixedUpdate();
    }

    //ChangeState
    public void ChangeState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentStateName = newState?.name;
        newState?.Enter();
    }
   
}
