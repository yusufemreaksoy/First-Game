﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private GameObject
        deathChunkParticle,
        deathBloodParticle;

    private float currentHealth;

    private GameManager GM;

    private HealtBar healtBar;

    private void Start()
    {
        currentHealth = maxHealth;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        healtBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealtBar>();
        healtBar.SetMaxHealth(maxHealth);
        Debug.Log("start" + healtBar.slider.value);
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;

        healtBar.SetHealth(currentHealth);
        Debug.Log("decrease" + healtBar.slider.value);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(deathChunkParticle, transform.position, deathChunkParticle.transform.rotation);

        Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);

        GM.Respawn();

        Destroy(gameObject);
    }

}
