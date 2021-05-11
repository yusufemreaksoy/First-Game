using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedState : State
{

    protected D_PlayerDetectedState stateData;

    protected bool
        isPlayerInMinAgroRange,
        isPlayerInMaxAgroRange,
        performLongRangeAction,
        performCloseRangeAction,
        isDetectedLedge;
    public PlayerDetectedState(Entity etity, FiniteStateMachine stateMachine, string animBoolName,D_PlayerDetectedState stateData) : base(etity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoCheks()
    {
        base.DoCheks();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
        isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
        isDetectedLedge = entity.CheckLedge();
    }

    public override void Enter()
    {
        base.Enter();
        performLongRangeAction = false;
        entity.SetVelocity(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startTime + stateData.longRangeActionTime)
        {
            performLongRangeAction = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
