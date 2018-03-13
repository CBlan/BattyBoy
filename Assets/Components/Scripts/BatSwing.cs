using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSwing : MonoBehaviour
{
    public GameObject player;

    public AnimationCurve swingPowerCurve;
    public float MaxSwingPower = 200;
    public KeyCode InputBatHit = KeyCode.Space;

    bool Swinging;
    float BatSwingPower;

    private void Update()
    {
        ProcessInput();
    }

    void ProcessInput() //process input
    {

        if (Input.GetKeyDown(InputBatHit))
        {
            StartCoroutine(CalculateHitStrength());
        }
        if (Input.GetKeyUp(InputBatHit))
        {
            StopCoroutine(CalculateHitStrength());
            StartCoroutine(Swing());
        }
    }

    public void OnCollisionStay(Collision other) //detects any hit object
    {
        if(Swinging)
        {
            if (other.gameObject.CompareTag("HitObject"))
            {
                print("HIT " + other.gameObject);
                other.gameObject.GetComponent<ObjectHitScore>().beenHit = true;
                other.gameObject.GetComponent<Rigidbody>().AddForce(player.transform.forward * BatSwingPower, ForceMode.Impulse);
                other.gameObject.GetComponent<ObjectHitScore>().ScoreAndDestroy();
            }
        }
    }

    IEnumerator CalculateHitStrength() //increases hitpower overtime.
    {
        float CurveTime = 0f;
        float CurvePosition = 0f;
        BatSwingPower = 0f;
        while (Input.GetKey(InputBatHit))
        {
            CurveTime += Time.deltaTime;
            CurvePosition = swingPowerCurve.Evaluate(CurveTime);
            BatSwingPower = MaxSwingPower * CurvePosition;
            yield return null;
        }

        print(BatSwingPower);
    }

    IEnumerator Swing()
    {
        Swinging = true;

        float timer = 0.6f;
        while(timer > 0)
        {
            timer -= Time.deltaTime;
        }

        Swinging = false;
        yield break;
    }

}