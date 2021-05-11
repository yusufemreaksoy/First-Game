using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = GetComponentInParent<Player>();
    }

    private void CheckAttackHitBox()
    {
        player.CheckAttakHitBox();
    }
}
