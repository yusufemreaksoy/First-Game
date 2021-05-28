using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStatsData
{
    public float health;

     public PlayerStatsData(PlayerStats player)
    {
        health = player.currentHealth;
    } 

}
