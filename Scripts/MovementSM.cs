using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : StateMachine
{
    [HideInInspector]
    public Idle IdleState;
    //[HideInInspector]
    //public moving MovingState;
    [HideInInspector]
    public Slither SlitherState;
    [HideInInspector]
    public Rolling RollingState;

    public Rigidbody2D xrigidbody;
    public SpriteRenderer xrenderer;
    public Animator animator;
   
    //public Transform transformController;

    public float speed = 4f;


    private void Awake()
    {
        IdleState = new Idle(this);
        SlitherState = new Slither(this);
        RollingState = new Rolling(this);
    }

    protected override BaseState GetInitialState()
    {
        base.GetInitialState();
        return IdleState;
    }
}
