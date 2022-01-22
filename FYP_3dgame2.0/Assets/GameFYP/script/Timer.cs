    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;
    private GameObject myTimer;
    public GameObject gameoverPanel;
    public GameObject backgroundMusic;

    private void Start()
    {
        timerIsRunning = true;
        myTimer = GameObject.Find("Timer");
        timeText = myTimer.GetComponent<Text>();
        backgroundMusic = GameObject.FindGameObjectWithTag("bgm");
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                gameoverPanel.SetActive(true);
                Invoke("LoadNextScene", 10f);
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void LoadNextScene()
    {
        //gameoverPanel.SetActive(false);
        if (backgroundMusic != null)
        {
            backgroundMusic.SetActive(false);
        }
        SceneManager.LoadScene(2);
    }
}
