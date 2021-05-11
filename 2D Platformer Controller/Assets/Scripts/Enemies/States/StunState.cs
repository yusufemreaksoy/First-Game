﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunState : State
{
    D_StunState stateData;

    protected bool isStunTimeOver,
        isGrounded,
        isMovementStopped,
        performCloseRangeAction,
        isPlayerInMinAgroRange;
    public StunState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_StunState stateData) : base(etity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoCheks()
    {
        base.DoCheks();
        isGrounded = entity.CheckGround();
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();

        isStunTimeOver = false;
        isMovementStopped = false;
        entity.SetVelocity(stateData.stunkKnockbackSpeed, stateData.stunKnockbackAngle, entity.lastDamageDirection);
    }

    public override void Exit()
    {
        base.Exit();
        entity.ResetStunResistance();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startTime + stateData.stunTime)
        {
            isStunTimeOver = true;
        }
        if(isGrounded&&Time.time >= startTime + stateData.stunKnockbackTime&&!isMovementStopped)
        {
            isMovementStopped = true;
            entity.SetVelocity(0f);
        }    
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
