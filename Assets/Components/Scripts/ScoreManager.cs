using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int playerScore;
    public static ScoreManager instance;


    public void Score(int pointsValue)
    {
        playerScore += pointsValue;
    }
}
