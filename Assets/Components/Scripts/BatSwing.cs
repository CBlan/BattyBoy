using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSwing : MonoBehaviour
{
    public GameObject player;
    public Transform point;
    float speed;
    float swingPower;
    public float maxSwingPower;
    float swingPowerPerTime = 1;

    bool hit;

    private void Start()
    {
        hit = false;
    }

    private void Update()
    {
        ProcessInput();
    }

    void ProcessInput() //process input
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("HitPower");
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            print(swingPower);
            StopCoroutine("HitPower");
            swingPower = 0f;
            if(hit == true)
            {
                StopCoroutine("SwingTimer");
                
            }
            hit = true;
            StartCoroutine("SwingTimer");
            transform.Rotate(90, 0, 0 * Time.deltaTime);
        }
        
    }
    

    void BatSwingAction()
    {
        //swings bat
        transform.Rotate(90, 0, 0);
    }

    

    public void OnCollisionEnter(Collision other) //detects any hit object
    {
        if (hit == true)
        {
            if (other.gameObject.CompareTag("HitObject"))
            {
                print("hit object");
                other.gameObject.GetComponent<Rigidbody>().AddForce(player.transform.forward * swingPower, ForceMode.Impulse);
                other.gameObject.GetComponent<ObjectHitScore>().beenHit = true;
                other.gameObject.GetComponent<ObjectHitScore>().ScoreAndDestroy();
            }
        }
        
    }

    IEnumerator HitPower() //increases hitpower overtime.
    {
        swingPower += swingPowerPerTime;
        if (swingPower > maxSwingPower)
        {
            swingPower = maxSwingPower;
        }
        yield return new WaitForSeconds(0.1f);
        StartCoroutine("HitPower");
        yield break;
    }

    IEnumerator SwingTimer()
    {
        print("time up");
        yield return new WaitForSeconds(0.8f);
        hit = false;
        transform.Rotate(90, 0, 0 * Time.deltaTime);

        yield break;
    }

}