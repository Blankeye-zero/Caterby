using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slither : moving
{
    //private MovementSM _sm;
    private float _horizontalInput;

    public slither(MovementSM stateMachine) : base("Slither", stateMachine)
    {
        //_sm = (MovementSM)stateMachine;
    }

    //public override void Enter()
    //{
    //    base.Enter();
    //    _horizontalInput = 0f;
    //}

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon)
            stateMachine.ChangeState(_sm.IdleState);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector2 vel = _sm.rigidbody.velocity;
        vel.x = _horizontalInput * _sm.speed;
        if (vel.x < 0)
            _sm.renderer.flipX = true;
        else
            _sm.renderer.flipX = false;
        _sm.rigidbody.velocity = vel;
        if (_sm.renderer.name == "mantisv10")
            _sm.animator.Play("Mantis-Run");
        else
            _sm.animator.Play("Slither");

    }
}
