using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newRangedAttackStateData", menuName = "Data/State Data/Ranged Attack State")]

public class D_RangedAttackState : ScriptableObject
{
    public GameObject projectile;

    public float projectTileDamage = 10f;
    public float projectTileSpeed = 12f;
    public float projectTileTravelDistance;
}
