using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudios : MonoBehaviour
{

    public AudioSource bark;
    public AudioSource rat;

    void Start()
    {
        Invoke("BarkSound", 2);
        Invoke("RatSound", 5);
    }

    private void BarkSound()
    {
        bark.Play();
        int random = Random.Range(5, 10);
        Invoke("BarkSound", random);
    }

    // Update is called once per frame
    private void RatSound()
    {
        rat.Play();
        int random = Random.Range(5, 10);
        Invoke("RatSound", random);
    }
}
