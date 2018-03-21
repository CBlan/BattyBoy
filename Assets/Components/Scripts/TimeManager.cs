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

	void Start ()
    {
        currentTime = timeValue;
        timerText.text = currentTime.ToString("00:00");
	}
	
	void Update ()
    {
        if(currentTime > 0)
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
        }
    }

    void TimeUp()
    {
        timeUpPanel.SetActive(true);
        
    }


}
