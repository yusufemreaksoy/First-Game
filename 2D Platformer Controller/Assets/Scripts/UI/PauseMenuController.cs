using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class PauseMenuController : MonoBehaviour
{
    private GameManager manager;

    public GameObject pauseMenu;
    public GameObject MenuButtons;


    private AudioManager audioManager;

    [SerializeField]
    private AudioMixer audioMixer;

    Resolution[] resolutions;

    [SerializeField]
    private TMP_Dropdown resulationDropdown;

    

    List<string> options = new List<string>();

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();

        resolutions = Screen.resolutions;
        resulationDropdown.ClearOptions();


        int currentResulationIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width==Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResulationIndex = i;
            }
        }

        resulationDropdown.AddOptions(options);
        resulationDropdown.value = currentResulationIndex;
        resulationDropdown.RefreshShownValue();
    }

    public void ChangeSFXVolume(float value)
    {
        audioMixer.SetFloat("SFXVolume", value);
    }

    public void ChangeMusicVolume(float value)
    {
        audioMixer.SetFloat("MusicVolume", value);
    }

    public void ChangeResulation(int resulationIndex)
    {
        Resolution resolution = resolutions[resulationIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void ChangeQuality(int Index)
    {
        QualitySettings.SetQualityLevel(Index);
    }

    public void ChangeFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void OpenMenuButtons()
    {
        pauseMenu.SetActive(false);
        MenuButtons.SetActive(true);
    }
    
    public void BackToPauseMenu()
    {
        MenuButtons.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void OpenOptions(GameObject target)
    {
        MenuButtons.SetActive(false);
        target.SetActive(true);
    }


    public void BackToMenuButtons(GameObject current)
    {
        current.SetActive(false);
        MenuButtons.SetActive(true);
    }
    

    public void Resume() => manager.SetPasueMenu(false);

    public void Quit() => Application.Quit();
}
