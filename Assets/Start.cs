using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class StartSimu : MonoBehaviour
{
    private int index;
    [SerializeField] private GameObject[] listFractures;
    [SerializeField] private GameObject[] listEntrainement;
    [SerializeField] private GameObject panelStart;
    [SerializeField] private GameObject panelFinish;
    [SerializeField] private GameObject buttonFinish;
    [SerializeField] private GameObject trainingButtonFinish;
    [SerializeField] private GameObject popUpPanel;
    [SerializeField] private GameObject trainingPopUpPanel;
    [SerializeField] private GameObject popUpPanelCase;
    [SerializeField] private GameObject timeGameObject;
    [SerializeField] private GameObject textFinishGameObject;
    [SerializeField] private TMP_Text TimeText;

    private float startTime;
    private bool timingStarted = false;

    public void StartSimulation()
    {
        panelStart.SetActive(false);
        panelFinish.SetActive(false);
        timeGameObject.SetActive(false);
        textFinishGameObject.SetActive(false);
        popUpPanelCase.SetActive(true);
        trainingPopUpPanel.SetActive(false);
    }
    public void CasEntrainement()
    {
        foreach (GameObject fracture in listEntrainement)
        {
            if (fracture.CompareTag("Training"))
            {
                fracture.SetActive(true);
            }
            else
            {
                fracture.SetActive(false);
            }
        }
        popUpPanelCase.SetActive(false);
        trainingButtonFinish.SetActive(true);
    }

    public void ChoixFracture(int i)
    {
        foreach (GameObject fracture in listFractures)
        {
            if (fracture.CompareTag("Fracture"+i.ToString()))
            {
                fracture.SetActive(true);
            }
            else
            {
                fracture.SetActive(false);
            }
        }
        popUpPanelCase.SetActive(false);
        buttonFinish.SetActive(true);
        startTime = Time.time;
        timingStarted = true;
        index = i;
    }

    public void FinishTrainingSimulation ()
    {
        foreach (GameObject fracture in listEntrainement)
        {
            if (fracture.CompareTag("Training"))
            {
                fracture.SetActive(false);
            }
        }
        trainingPopUpPanel.SetActive(true);
        trainingButtonFinish.SetActive(false);
    }

    public void FinishSimulation ()
    {
        
        foreach (GameObject fracture in listFractures)
        {
            if (fracture.CompareTag("Fracture" + index.ToString()))
            {
                fracture.SetActive(false);
            }
        }
        popUpPanel.SetActive(true);
        buttonFinish.SetActive(false);
    }

    public void TrainingContinue()
    {
        foreach (GameObject fracture in listEntrainement)
        {
            if (fracture.CompareTag("Training"))
            {
                fracture.SetActive(true);
            }
        }
        panelFinish.SetActive(false);
        trainingButtonFinish.SetActive(true);
        trainingPopUpPanel.SetActive(false);
    }

    public void SimulationContinue()
    {
        foreach (GameObject fracture in listFractures)
        {
            if (fracture.CompareTag("Fracture" + index.ToString()))
            {
                fracture.SetActive(true);
            }
        }
        panelFinish.SetActive(false);
        buttonFinish.SetActive(true);
        popUpPanel.SetActive(false);
        timingStarted = true;
    }

    public void SimulationFinish()
    {
        foreach (GameObject fracture in listFractures)
        {
            if (fracture.CompareTag("Fracture" + index.ToString()))
            {
                fracture.SetActive(false);
            }
        }
        
        buttonFinish.SetActive(false);
        panelFinish.SetActive(true);
        popUpPanel.SetActive(false);
        textFinishGameObject.SetActive(true);
        timeGameObject.SetActive(true);
        if (timingStarted)
        {
            float elapsedTime = (Time.time - startTime);
            var minutes = elapsedTime / 60;
            var seconds = elapsedTime % 60;
            timingStarted = false;
            string formatTime = string.Format("{0:00}:{1:00}", minutes, seconds);
            TimeText.text = "Temps total : " + formatTime;
        }
    }
}
