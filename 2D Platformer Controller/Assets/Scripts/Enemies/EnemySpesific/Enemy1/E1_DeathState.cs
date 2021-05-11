using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_DeathState : DeathState
{
    private Enemy1 enemy;
    public E1_DeathState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_DeathState stateData, Enemy1 enemy) : base(etity, stateMachine, animBoolName, stateData)
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
