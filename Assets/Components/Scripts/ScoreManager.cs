using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //Score values
    public int playerScore;
    public int rank;
    public int[] rankValue;

    //UI Values
    public Text score;

    //Managers
    public static ScoreManager instance;


    public void Start()
    {
        rank = 1;
        instance = this;
        score.text = "Score: " + playerScore.ToString();
    }

    

    public void Score(int pointsValue)
    {
        playerScore += pointsValue;
        score.text = "Score: " + playerScore.ToString();

    }

    public void RankUp()
    {
        if(playerScore > rankValue[0] && playerScore < rankValue[1])
        {
            rank = 2;
        }
        if(playerScore > rankValue[1])
        {
            rank = 3;
        }


    }


}
