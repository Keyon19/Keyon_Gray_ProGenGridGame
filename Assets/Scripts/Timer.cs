using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeStart;
    public bool timeActive = false;

    public TextMeshProUGUI TimerText;

    void Start()
    {
        timeActive = true;
    }

    void Update()
    {
        if (timeActive)
        {
            if(timeStart > 0) { 
                timeStart -= Time.deltaTime;
                updateTimer(timeStart);
            } else
            {
                timeStart = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }            
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;
        
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
