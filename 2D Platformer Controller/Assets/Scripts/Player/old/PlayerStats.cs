using System.Collections;
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
    [HideInInspector]
    public float currentHealth;

    private GameManager GM;

    private HealtBar healtBar;

    private Player player;

    private bool isTouchingTraps;

    private void Update()
    {
        isTouchingTraps = player.CheckForTraps();
        if (isTouchingTraps)
        {
            Die();
        }
    }
    private void Start()
    {
        currentHealth = maxHealth;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GetComponent<Player>();
        healtBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealtBar>();
        healtBar.SetMaxHealth(maxHealth);
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;

        healtBar.SetHealth(currentHealth);
        Debug.Log("decrease" + currentHealth);

        if (currentHealth <= 0 )
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "StageEnd")
        {
            GM.NextLevel();
        }
    }

}
