using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    //public Timer timer;
    public PlayerControl playerControl;

    public float timeStart;
    public bool timeActive = false;

    public TextMeshProUGUI TimerText;

    /*
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
*/
    void Start()
    {
        //timer.PauseTimer();
        timeActive = true;
    }

    
    void Update()
    {
        if (timeActive)
        {
            if (timeStart > 0)
            {
                timeStart -= Time.deltaTime;
                updateTimer(timeStart);
            }
            else
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


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
