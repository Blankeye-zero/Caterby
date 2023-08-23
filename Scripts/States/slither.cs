using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slither : Moving
{
    private float _horizontalInput;

    public Slither(MovementSM stateMachine) : base("Slither", stateMachine)
    {
    }

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
        Vector2 vel = _sm.xrigidbody.velocity;
        vel.x = _horizontalInput * _sm.speed;
        if (vel.x < 0)
            if (_sm.xrenderer.name.Contains("mantis"))
                _sm.xrenderer.flipX = false;
            else
                _sm.xrenderer.flipX = true;
        else
            if (_sm.xrenderer.name.Contains("mantis"))
            _sm.xrenderer.flipX = true;
        else
            _sm.xrenderer.flipX = false;
        _sm.xrigidbody.velocity = vel;
        if (_sm.xrenderer.name.Contains("mantis"))
            _sm.animator.Play("Mantis-Run");
        else
            _sm.animator.Play("Slither");

    }
}
