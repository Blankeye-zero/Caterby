using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idle : BaseState
{
    private float _horizontalInput;

    private MovementSM _sm;
    public idle(MovementSM stateMachine) : base("Idle", stateMachine) {
        //if (transformController.localRotation.z < 0)
        //{
        //    transformController.localRotation = new Quaternion(0, 0, 0, 0);
        //}
        _sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
            stateMachine.ChangeState(_sm.SlitherState);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        if (_sm.renderer.name == "mantisv10")
            _sm.animator.Play("Mantis-Idle");
        else
        _sm.animator.Play("Idle");
    }
}
