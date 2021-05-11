using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform respawnPoint;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float respawnTime;

    private float respawnStartTime;

    private bool respawn;

    private CinemachineVirtualCamera cvc;

    private void Start()
    {
        cvc = GameObject.Find("Player Camera").GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        CheckRespawn();
    }

    public void Respawn()
    {
        respawnStartTime = Time.time;
        respawn = true;
    }

    private void CheckRespawn()
    {
        if(Time.time >= respawnStartTime + respawnTime && respawn)
        {
            var playerTemp = Instantiate(player, respawnPoint);
            cvc.m_Follow = playerTemp.transform;
            respawn = false;
        }
    }
}
