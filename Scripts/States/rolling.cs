using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling : Moving
{
    private float _horizontalInput;
    private float waitTime = 1.0f;
    private float timer = 0.0f;

    public Rolling(MovementSM stateMachine) : base("Rolling", stateMachine)
    {
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        timer += Time.deltaTime;
        _horizontalInput = Input.GetAxis("Horizontal");
        if (timer >= waitTime)
        {
            timer = 0.0f;
            stateMachine.ChangeState(_sm.IdleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector2 vel = _sm.xrigidbody.velocity;
        vel.x = _horizontalInput * 8f;
        if (_sm.xrenderer.name.Contains("mantis"))
        {
            _sm.animator.Play("Mantis-Attack");
        }
        else
        {
            _sm.animator.Play("Rolling");

        }
        _sm.xrigidbody.velocity = vel;            
    }
}
