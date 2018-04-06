using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHitScore : MonoBehaviour
{
    public int scoreValue; //Point value
    public bool beenHit;
    public float timeToDestroy = 8f;
    public GameObject destroyEffect;

    public void ScoreAndDestroy()
    {
        if (beenHit)
        {

            ScoreManager.instance.Score(scoreValue); //Give the score tracker(player/game/score manager) and add it.
            ScoreManager.instance.RankUp();
            //print("I HAVE BEEN HIT!");
            StartCoroutine("DestroyItem");
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

            if (collision.gameObject.CompareTag("LightObject") || collision.gameObject.CompareTag("MediumObject") || collision.gameObject.CompareTag("HeavyObject"))
            {
                if(ScoreManager.instance.rank == 1 && collision.gameObject.CompareTag("LightObject"))
                {
                    collision.gameObject.GetComponent<ObjectHitScore>().beenHit = true;
                    collision.gameObject.GetComponent<ObjectHitScore>().ScoreAndDestroy();
                }
                if (ScoreManager.instance.rank == 2)
                {
                    if(collision.gameObject.tag != "HeavyObject")
                    {
                        collision.gameObject.GetComponent<ObjectHitScore>().beenHit = true;
                        collision.gameObject.GetComponent<ObjectHitScore>().ScoreAndDestroy();
                    }
                }
                if (ScoreManager.instance.rank >= 3)
                {
                    collision.gameObject.GetComponent<ObjectHitScore>().beenHit = true;
                    collision.gameObject.GetComponent<ObjectHitScore>().ScoreAndDestroy();
                }
                
            }

            //if (gameObject.tag == "LightObject")
            //{
            //    Fabric.EventManager.Instance.PostEvent("Hit/Small");
            //}
            //if (gameObject.tag == "MediumObject")
            //{
            //    Fabric.EventManager.Instance.PostEvent("Hit/Medium");
            //}
            //if (gameObject.tag == "HeavyObject")
            //{
            //    Fabric.EventManager.Instance.PostEvent("Hit/Large");
            //}

        }
    }

    IEnumerator DestroyItem()
    {
        yield return new WaitForSeconds(timeToDestroy-1f);
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        //if (gameObject.tag == "LightObject")
        //{
        //    Fabric.EventManager.Instance.PostEvent("Hit/Small");
        //}
        //if (gameObject.tag == "MediumObject")
        //{
        //    Fabric.EventManager.Instance.PostEvent("Hit/Medium");
        //}
        //if (gameObject.tag == "HeavyObject")
        //{
        //    Fabric.EventManager.Instance.PostEvent("Hit/Large");
        //}
        ScoreManager.instance.objectsCleared++;
        Destroy(gameObject);
    }

}
