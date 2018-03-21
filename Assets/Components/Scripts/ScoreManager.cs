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
    public Text rankText;

    //Managers
    public static ScoreManager instance;


    public void Start()
    {
        rankText.text = "Rank 1";
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
            rankText.text = "Rank 2";
            rank = 2;
        }
        if(playerScore > rankValue[1])
        {
            rankText.text = "Final Rank";
            rank = 3;
        }


    }


}
