using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : BaseState
{
    protected MovementSM _sm;
    private float _horizontalInput;

    public moving(string name, MovementSM stateMachine) : base(name, stateMachine) {
        _sm = (MovementSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (Input.GetKeyDown(KeyCode.Space)) {
            stateMachine.ChangeState(_sm.RollingState);
        }
            
    }
}
