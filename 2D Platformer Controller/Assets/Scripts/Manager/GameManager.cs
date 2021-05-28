using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("Respawn Variables")]
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private float respawnTime;
    [Header("Pause Variables")]
    [SerializeField] private GameObject PauseMenuUI;

    private float respawnStartTime;

    private bool respawn;
    private bool pause;

    private LevelLoader levelLoader;

    private PlayerInputHandler inputHandler;
    private CinemachineVirtualCamera cvc;

    private void Start()
    {
        cvc = GameObject.Find("Player Camera").GetComponent<CinemachineVirtualCamera>();

        inputHandler = GetComponent<PlayerInputHandler>();

        levelLoader = FindObjectOfType<LevelLoader>();
    }

    public void NextLevel()
    {
        levelLoader.LoadScene();
    }



    private void Update()
    {
        CheckRespawn();
        pause = inputHandler.PauseInput;
        CheckPause();
    }

    public void Respawn()
    {
        respawnStartTime = Time.time;
        respawn = true;
    }

    private void CheckRespawn()
    {
        if (Time.time >= respawnStartTime + respawnTime && respawn)
        {
            var playerTemp = Instantiate(playerPrefab, respawnPoint);
            cvc.m_Follow = playerTemp.transform;
            respawn = false;
        }
    }

    private void CheckPause()
    {
        if (pause)
        {
            SetPasueMenu(true);
        }
    }

    public void SetPasueMenu(bool value)
    {
        PauseMenuUI.SetActive(value);
        if (value)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

}
