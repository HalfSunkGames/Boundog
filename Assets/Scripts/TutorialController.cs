using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> tutorialPanels;
    private int currentTutorial = 0;

    private void Start()
    {
        tutorialPanels = new List<GameObject>();

        foreach(Transform child in this.transform)
        {
            GameObject obj = child.gameObject;
            tutorialPanels.Add(obj);
        }
    }

    public void NextTutorial()
    {
        tutorialPanels[currentTutorial].SetActive(false);
        currentTutorial++;
        tutorialPanels[currentTutorial].SetActive(true);       
    }
}
