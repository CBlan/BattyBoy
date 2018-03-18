using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BatSwing : MonoBehaviour
{
    public GameObject player;

    public AnimationCurve swingPowerCurve;
    public float MaxSwingPower = 200;
    public KeyCode InputBatHit = KeyCode.Space;
    public float maxDistance;
    public GameObject hitObject;


    bool Swinging;
    public float BatSwingPower;

    Color debugColor = Color.red;

    private void Update()
    {
        ProcessInput();
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if (hit.collider.gameObject.CompareTag("HitObject"))
            {
                if (Vector3.Distance(transform.position, hit.point) < 2f)
                {
                    hitObject = hit.collider.gameObject;
                    debugColor = Color.green;
                }
            }

            if (hit.collider.gameObject.CompareTag("People"))
            {
                if (Vector3.Distance(transform.position, hit.point) < 2f)
                {
                    hitObject = hit.collider.gameObject;
                    debugColor = Color.green;
                }
                
            }

        }
        else
        {
            debugColor = Color.red;
            hitObject = null;
        }

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 4, debugColor);
    }

    void ProcessInput() //process input
    {
        #region BatSwing Increase overtime input
        //if (Input.GetKeyDown(InputBatHit) || Input.GetMouseButtonDown(0))
        //{
        //    StartCoroutine(CalculateHitStrength());
        //}
        //if (Input.GetKeyUp(InputBatHit) || Input.GetMouseButtonUp(0))
        //{
        //    StopCoroutine(CalculateHitStrength());

        //    if (hitObject != null)
        //    {

        //        if(hitObject.tag == "HitObject")
        //        {
        //            hitObject.gameObject.GetComponent<ObjectHitScore>().beenHit = true;
        //            hitObject.gameObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * BatSwingPower, ForceMode.Impulse);
        //            hitObject.gameObject.GetComponent<ObjectHitScore>().ScoreAndDestroy();
        //            hitObject = null;
        //        }
        //        else if (hitObject.tag == "People")
        //        {
        //            hitObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * BatSwingPower, ForceMode.Impulse);
        //            hitObject.GetComponent<NavMeshAgent>().enabled = false;
        //            hitObject.GetComponent<AIMovement>().enabled = false;
        //            hitObject = null;
        //        }

        //    }

        //    StartCoroutine(Swing());
        //}

        #endregion


        if (Input.GetKeyDown(InputBatHit) || Input.GetMouseButtonDown(0))
        {
            if (hitObject != null)
            {

                if (hitObject.tag == "HitObject")
                {
                    hitObject.gameObject.GetComponent<ObjectHitScore>().beenHit = true;
                    hitObject.gameObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * BatSwingPower, ForceMode.Impulse);
                    hitObject.gameObject.GetComponent<ObjectHitScore>().ScoreAndDestroy();
                    //hitObject = null;
                }
                else if (hitObject.tag == "People")
                {
                    hitObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * BatSwingPower, ForceMode.Impulse);
                    hitObject.GetComponent<NavMeshAgent>().enabled = false;
                    hitObject.GetComponent<AIMovement>().enabled = false;
                    //hitObject = null;
                }

            }
        }
    }

    IEnumerator CalculateHitStrength() //increases hitpower overtime.
    {
        float CurveTime = 0f;
        float CurvePosition = 0f;
        BatSwingPower = 0f;
        while (Input.GetKey(InputBatHit) || Input.GetMouseButton(0))
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