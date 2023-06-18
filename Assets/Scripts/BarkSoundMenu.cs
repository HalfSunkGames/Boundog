using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkSoundMenu : MonoBehaviour
{
    private AudioSource bark;

    // Start is called before the first frame update
    void Start()
    {
        bark = GetComponent<AudioSource>();
    }

    private void BarkSound()
    {
        bark.Play();
    }
}
