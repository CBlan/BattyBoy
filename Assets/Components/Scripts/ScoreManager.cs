using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int playerScore;
    public static ScoreManager instance;
    public Text score;

    public void Start()
    {
        instance = this;
        score.text = "Score: " + playerScore.ToString();
    }

    public void Score(int pointsValue)
    {
        playerScore += pointsValue;
        score.text = "Score: " + playerScore.ToString();

    }
}
