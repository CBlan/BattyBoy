using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float timeValue;
    float currentTime;

    public Text timerText;
    public GameObject timeUpPanel;

    public bool hasMoved;

	void Start ()
    {
        hasMoved = false;
        currentTime = timeValue;
        timerText.text = currentTime.ToString("00:00");
        timerText.enabled = false;
	}
	
	void Update ()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if (inputX != 0 || inputY != 0)
        {
            hasMoved = true;
            timerText.enabled = true;
        }

        if (currentTime > 0 && hasMoved)
        {
            ProcessTime();
        }
    }

    void ProcessTime()
    {
        string minutes = Mathf.Floor(currentTime / 60).ToString("00");
        string seconds = Mathf.RoundToInt(currentTime % 60).ToString("00");

        //if (minutes < 10)
        //{
        //    minutes = "0" + minutes.ToString();
        //}
        //if (seconds < 10)
        //{
        //    seconds = "0" + Mathf.RoundToInt(seconds).ToString();
        //}
        //GUI.Label(new Rect(10, 10, 250, 100), minutes + ":" + seconds);

        timerText.text = minutes + ":" + seconds;


        //timerText.text = currentTime.ToString("00:00");
        currentTime -= Time.deltaTime;


        if (currentTime <= 0)
        {
            currentTime = 0;
            TimeUp();
            ScoreManager.instance.GameOver();
        }
    }

    void TimeUp()
    {
        PauseManager.instance.PauseGame();
        timeUpPanel.SetActive(true);
        
    }


}
