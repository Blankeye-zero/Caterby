using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rolling : moving
{
    //private MovementSM _sm;
    private float _horizontalInput;
    private float waitTime = 1.0f;
    private float timer = 0.0f;

    public rolling(MovementSM stateMachine) : base("Rolling", stateMachine)
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
        timer += Time.deltaTime;
        _horizontalInput = Input.GetAxis("Horizontal");
        if (timer >= waitTime)
        {
            timer = 0.0f;
            stateMachine.ChangeState(_sm.IdleState);
        }
        //if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon)
        //    stateMachine.ChangeState(_sm.IdleState);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector2 vel = _sm.rigidbody.velocity;
        vel.x = _horizontalInput * 8f;
        if (vel.x < 0)
            _sm.renderer.flipX = true;
        else
            _sm.renderer.flipX = false;
        _sm.rigidbody.velocity = vel;
        if (_sm.renderer.name == "mantisv10")
            _sm.animator.Play("Mantis-Attack");
        else
            _sm.animator.Play("Rolling");
    }
}
