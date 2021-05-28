using System.Collections;
using UnityEngine;


public class MainMenuController : MonoBehaviour
{
    private LevelLoader levelLoader;

    private void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
    }

    public void Play()
    {
        levelLoader.LoadScene();
    }



    public void Quit()
    {
        Application.Quit();
    }

    
}
