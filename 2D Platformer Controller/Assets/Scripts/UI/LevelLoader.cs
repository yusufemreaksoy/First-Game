using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    public Slider slider;
    public Animator transition;
    public GameObject loadingScreen;

    public float transitionTime = 1f;
    [SerializeField]
    private GameObject startMenu;

    private float startTime;

    private bool isInStartMenu;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            //startMenu = GameObject.FindGameObjectWithTag("Menu");
            //Debug.Log(startMenu.tag);
            isInStartMenu = true;
        }
    }

    private void Start()
    {
        if(isInStartMenu)
        {
            startTime = Time.time;
        }
    }

    private void Update()
    {
        if(Time.time >= startTime + 1f)
        {
            startMenu.SetActive(true);
            //Debug.Log(startMenu.name);
            return;
        }
    }

    public void LoadScene()
    {
        if (isInStartMenu)
        {
            startMenu.SetActive(false);
        }
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadScene(int buildIndex)
    {

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        AsyncOperation operation = SceneManager.LoadSceneAsync(buildIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            yield return null;
        }
    }

}
