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
    public int grade;
    public int[] gradeValue;
    

    //UI Values
    public Text scoreText;
    public Text resultsText;
    public Text gradeText;

    //Managers
    public static ScoreManager instance;



    public void Start()
    {
        rank = 1;
        instance = this;
        scoreText.text = "Score: " + playerScore.ToString();
    }

    public void Update()
    {
        
    }

    public void Score(int pointsValue)
    {
        playerScore += pointsValue;
        scoreText.text = "Score: " + playerScore.ToString();
        if(gradeValue.Length > 0)
        {
            CheckRank();
        }

    }

    void CheckRank()
    {
        grade = 0;

        if(gradeValue[0] <= playerScore)
        {
            grade = 1;

            if (gradeValue[1] <= playerScore)
            {
                grade = 2;

                if (gradeValue[2] <= playerScore)
                {
                    grade = 3;
                }

            }
            
        }
    }

    public void GameOver()
    {
        resultsText.text = "You've managed to destroy $" + playerScore + " worth of items.";


        if (gradeValue.Length > 0)
        {
            if (grade == 0)
            {
                gradeText.text = "Rank: D-!";
            }
            if (grade == 1)
            {
                gradeText.text = "Rank: C!";
            }
            if (grade == 2)
            {
                gradeText.text = "Rank: B!";
            }
            if (grade == 3)
            {
                gradeText.text = "Rank: A+!";
            }


        }
        



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
