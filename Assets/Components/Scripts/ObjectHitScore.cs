using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHitScore : MonoBehaviour
{
    public int scoreValue; //Point value
    public bool beenHit;

    public void ScoreAndDestroy()
    {
        if (beenHit)
        {
            ScoreManager.instance.Score(scoreValue); //Give the score tracker(player/game/score manager) and add it.
            print("I HAVE BEEN HIT!");
            //Destroy(gameObject, 5); //Destroy the gameobject.
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (beenHit)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<EnemyMovement>().Stunned();
            }
        }
    }

}
