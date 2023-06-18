using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MenuController : MonoBehaviour
{
    public GameObject optionPanel;
    public GameObject menuPanel;
    public GameObject bgIntro;
    public GameObject creditsPanel;
    public GameObject selectorPanel;

    private void Awake()
    {
        Time.timeScale = 1;
        optionPanel.SetActive(false);
        creditsPanel.SetActive(false);
        selectorPanel.SetActive(false);
        Invoke("DestroyIntro", 2.2f);
    }


    private void DestroyIntro()
    {
        bgIntro.SetActive(false);
    }

    public void StartGame()
    {
        // Esto habrá que cambiarlo una vez decidido el orden de la build
        Scene scene;
        scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(scene.buildIndex + 1);
    }

    public void OpenCloseOptions()
    {
        optionPanel.SetActive(!optionPanel.activeInHierarchy);
        menuPanel.SetActive(!menuPanel.activeInHierarchy);
    }

    public void OpenCloseCredits()
    {
        creditsPanel.SetActive(!creditsPanel.activeInHierarchy);
        menuPanel.SetActive(!menuPanel.activeInHierarchy);
    }

    public void OpenCloseLvlSelector()
    {
        selectorPanel.SetActive(!selectorPanel.activeInHierarchy);
        menuPanel.SetActive(!menuPanel.activeInHierarchy);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Juego cerrado");
    }

    public void SelectLvl(int lvl)
    {
        SceneManager.LoadScene(lvl+2);
    }
}
