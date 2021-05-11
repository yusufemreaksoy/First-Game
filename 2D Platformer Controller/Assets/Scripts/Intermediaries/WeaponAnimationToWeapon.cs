using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimationToWeapon : MonoBehaviour
{
    private Weapon weapon;
    private Player player;

    private void Start()
    {
        weapon = GetComponentInParent<Weapon>();
        player = GetComponentInParent<Player>();
    }

    private void AnimationFinishTrigger()
    {
        weapon.AnimationFinishTrigger();
    }

    private void AnimationStartMovementTrigger()
    {
        weapon.AnimationStartMovementTrigger();
    }

    private void AnimationStopMovementTrigger()
    {
        weapon.AnimationStopMovementTrigger();
    }

    private void AnimationTurnOffFlipTrigger()
    {
        weapon.AnimationTurnOffFlipTrigger();
    }
    private void AnimationTurnOnFlipTrigger()
    {
        weapon.AnimationTurnOnFlipTrigger();
    }

    private void CheckAttackHitBox()
    {
        player.CheckAttakHitBox();
    }
}
