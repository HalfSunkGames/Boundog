using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryMusic : MonoBehaviour
{
    public GameObject music;
    private AudioSource bgnMusic;
    private AudioSource victoryMusic;

    void Start()
    {
        bgnMusic = music.GetComponent<AudioSource>();
        victoryMusic = GetComponent<AudioSource>();
    }

    public void WinSound()
    {
        bgnMusic.Stop();
        victoryMusic.Play();
    }
}
