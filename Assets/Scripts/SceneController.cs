using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneController : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject tutorialPanel;
    public GameObject goPanel;
    public GameObject winPanel;
    public GameObject music;

    private AudioSource bgnMusic;
    private AudioSource victoryMusic;

    public bool needsTutorial;
    private bool tutorialSeen = false;

    public bool isPaused = false;
    private PlayerController player;

    public int numRats;

    void Awake()
    {
        Time.timeScale = 1;
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        pausePanel.SetActive(false);
        goPanel.SetActive(false);
        winPanel.SetActive(false);
        bgnMusic = music.GetComponent<AudioSource>();
        victoryMusic = GetComponent<AudioSource>();

        if (needsTutorial && !tutorialSeen)
        {
            Time.timeScale = 0;
            tutorialPanel.SetActive(true);
        }
    }

    void Update()
    {
        // Pause
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseOrUnpause();
        }

        // Game Over
        if (player.treats == 0)
        {
            GameOver();
        }
    }

    public void KilledRat()
    {
        numRats = numRats - 1;
        if (numRats == 0)
        {
            bgnMusic.Stop();
            victoryMusic.Play();
            Invoke("Win", 1);
        }   
    }

    public void PauseOrUnpause()
    {
        // Pause
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            isPaused = true;
            pausePanel.SetActive(true);

        }// Unpause
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            isPaused = false;
            pausePanel.SetActive(false);
        }
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Win()
    {
        Time.timeScale = 0;
        isPaused = true;
        winPanel.SetActive(true);
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        isPaused = true;
        goPanel.SetActive(true);
    }

    public void Retry()
    {
        Debug.Log("Retry");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void NextScene()
    {
        Scene scene;
        scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(scene.buildIndex + 1);
    }

    public void CloseTutorial()
    {
        tutorialSeen = true;
        tutorialPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
