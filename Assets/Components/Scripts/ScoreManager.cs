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
            grade = 0;

            if (gradeValue[1] <= playerScore)
            {
                grade = 1;

                if (gradeValue[2] <= playerScore)
                {
                    grade = 2;

                    if (gradeValue[3] <= playerScore)
                    {
                        grade = 3;

                        if (gradeValue[4] <= playerScore)
                        {
                            grade = 4;

                            if (gradeValue[5] <= playerScore)
                            {
                                grade = 5;

                                if (gradeValue[6] <= playerScore)
                                {
                                    grade = 6;

                                    if (gradeValue[7] <= playerScore)
                                    {
                                        grade = 7;

                                        if(gradeValue[8] <= playerScore)
                                        {
                                            grade = 8;

                                            if (gradeValue[9] <= playerScore)
                                            {
                                                grade = 9;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
             
            }
            
        }
    }

    public void GameOver()
    {
        resultsText.text = "You've managed to destroy <color=green>$" + playerScore + "</color> worth of items.";


        if (gradeValue.Length > 0)
        {
            if (grade == 0)
            {
                gradeText.text = "Rank: <color=red>C- !</color>";
            }
            if (grade == 1)
            {
                gradeText.text = "Rank: <color=red>C !</color>";
            }
            if (grade == 2)
            {
                gradeText.text = "Rank: <color=red>C+ !</color>";
            }
            if (grade == 3)
            {
                gradeText.text = "Rank: <color=yellow>B- !</color>";
            }
            if (grade == 4)
            {
                gradeText.text = "Rank: <color=yellow>B !</color>";
            }
            if (grade == 5)
            {
                gradeText.text = "Rank: <color=yellow>B+ !</color>";
            }
            if (grade == 6)
            {
                gradeText.text = "Rank: <color=green>A- !</color>";
            }
            if (grade == 7)
            {
                gradeText.text = "Rank: <color=green>A !</color>";
            }
            if (grade == 8)
            {
                gradeText.text = "Rank: <color=green>A+ !</color>";
            }
            if (grade == 9)
            {
                gradeText.text = "Rank: <color=green>S !</color>";
            }
        }
        



    }

    public void RankUp()
    {
        if(playerScore > rankValue[0] && playerScore < rankValue[1])
        {
            rank = 2;
        }
        if(playerScore > rankValue[1] && playerScore < rankValue[2])
        {
            rank = 3;
        }
        if (playerScore > rankValue[2])
        {
            rank = 4;
        }
    }


}
