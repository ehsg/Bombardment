using UnityEngine;

public class Walking : State
{
    private PlayerController controller;
    public Walking(PlayerController controller) : base("Walking")
    {
        this.controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }
    
    public override void Update()
    {
        base.Update();
        //switch to idle
        if (controller.movementVector.IsZero())
        {
            controller.stateMachine.ChangeState(controller.idleState);
            return;
        }

        /*
        Check keys pressed, used before vectors
        //Read Input
        bool isUp = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        bool isDown = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        bool isLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        bool isRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

        //Create movement Vector
        float movementZ = isUp ? 1 : isDown ? -1 : 0;
        float movementX = isRight ? 1 : isLeft ? -1 : 0;
        */

        //Control using Vector
        //X = Esquerda negativo ou Direita positivo, Y = Cima positivo ou baixo negativo


        Vector3 walkVector = new Vector3(controller.movementVector.x, 0, controller.movementVector.y);
        walkVector *= controller.movementSpeed * Time.deltaTime;
        //Apply inout to Character
        controller.transform.Translate(walkVector);
    }

    public override void LateUpdate()
    {
        base.LateUpdate();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}