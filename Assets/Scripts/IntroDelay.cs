using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroDelay : MonoBehaviour
{
    VideoPlayer intro;
    // Start is called before the first frame update
    void Start()
    {
        intro = GetComponent<VideoPlayer>();
        StartCoroutine(Wait());
        StartCoroutine(GoMenu());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        intro.Play();
    }

    IEnumerator GoMenu()
    {
        yield return new WaitForSeconds(7.3f);
        SceneManager.LoadScene(1);
    }
}
