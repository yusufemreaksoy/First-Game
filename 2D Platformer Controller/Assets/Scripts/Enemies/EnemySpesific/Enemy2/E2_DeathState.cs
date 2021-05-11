using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_DeathState : DeathState
{
    Enemy2 enemy;
    public E2_DeathState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_DeathState stateData,Enemy2 enemy) : base(etity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void DoCheks()
    {
        base.DoCheks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
