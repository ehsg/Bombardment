using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public Properties
    public float movementSpeed  = 10;
    //State Machine
    [HideInInspector] public StateMachine stateMachine;
    [HideInInspector] public Idle idleState;
    [HideInInspector] public Walking walkingState;
    //Internal Properties
    [HideInInspector] public Vector2 movementVector;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new StateMachine();
        idleState = new Idle(this);
        walkingState = new Walking(this);
        stateMachine.ChangeState(idleState);        
    }

    // Update is called once per frame
    void Update()
    {
        //Create Input Vector
        bool isUp = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        bool isDown = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        bool isLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        bool isRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        float inputY = isUp ? 1 : isDown ? -1 : 0;
        float inputX = isRight ? 1 : isLeft ? -1 : 0;
        movementVector = new Vector2(inputX, inputY);
        stateMachine.Update();

        //CONTROL PLAYER WIHTOUT STATEMACHINE
        //Read Input
        //bool isUp = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        //bool isDown = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        //bool isLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        //bool isRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

        //Create movement Vector
        //float movementZ = isUp ? 1 : isDown ? -1 : 0;
        //float movementX = isRight ? 1 : isLeft ? -1 : 0;
        //Vector3 movementVector = new Vector3(movementX, 0, movementZ);

        //Apply inout to Charachter
        //transform.Translate(movementVector * movementSpeed * Time.deltaTime);
    }
}
