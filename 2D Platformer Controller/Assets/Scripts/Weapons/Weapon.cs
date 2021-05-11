using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private SO_WeaponData weaponData;

    protected Animator baseAnim;
    protected Animator weaponAnim;

    protected PlayerAttackState state;

    protected int attackCounter;

    public float damageAmount = 10f;
    public float StunDamageAmount = 1f;


    protected virtual void Start()
    {
        baseAnim = transform.Find("Base").GetComponent<Animator>();
        weaponAnim = transform.Find("Weapon").GetComponent<Animator>();

        gameObject.SetActive(false);
    }

    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);

        if (attackCounter >= weaponData.movementSpeed.Length)
        {
            attackCounter = 0;
        }

        baseAnim.SetBool("attack", true);
        weaponAnim.SetBool("attack", true);

        baseAnim.SetInteger("attackCounter", attackCounter);
        weaponAnim.SetInteger("attackCounter", attackCounter);
    }

    public virtual void ExitWeapon()
    {
        baseAnim.SetBool("attack", false);
        weaponAnim.SetBool("attack", false);

        attackCounter++;

        gameObject.SetActive(false);
    }

    #region Animation Triggers

    public virtual void AnimationFinishTrigger()
    {
        state.AnimationFinishTrigger();
    } 

    public virtual void AnimationStartMovementTrigger()
    {
        state.SetPlayerVelocity(weaponData.movementSpeed[attackCounter]);
    }

    public virtual void AnimationStopMovementTrigger()
    {
        state.SetPlayerVelocity(0f);
    }

    public virtual void AnimationTurnOffFlipTrigger()
    {
        state.SetFlipChek(false);
    }

    public virtual void AnimationTurnOnFlipTrigger()
    {
        state.SetFlipChek(true);
    }

    #endregion

    public void InitializeWeapon(PlayerAttackState state)
    {
        this.state = state;
    }

}
