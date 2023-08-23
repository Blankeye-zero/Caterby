using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : BaseState
{
    protected MovementSM _sm;

    public Moving(string name, MovementSM stateMachine) : base(name, stateMachine) {
        _sm = (MovementSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (Input.GetKeyDown(KeyCode.Space)) {
            stateMachine.ChangeState(_sm.RollingState);
        }
            
    }
}
