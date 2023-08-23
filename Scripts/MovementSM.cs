using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : StateMachine
{
    [HideInInspector]
    public idle IdleState;
    //[HideInInspector]
    //public moving MovingState;
    [HideInInspector]
    public slither SlitherState;
    [HideInInspector]
    public rolling RollingState;

    public Rigidbody2D rigidbody;
    public SpriteRenderer renderer;
    public Animator animator;
   
    //public Transform transformController;

    public float speed = 4f;


    private void Awake()
    {
        IdleState = new idle(this);
        SlitherState = new slither(this);
        RollingState = new rolling(this);
    }

    protected override BaseState GetInitialState()
    {
        base.GetInitialState();
        return IdleState;
    }
}
