using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSwing : MonoBehaviour
{
    public GameObject player;

    public AnimationCurve swingPowerCurve;
    public float MaxSwingPower = 200;
    public KeyCode InputBatHit = KeyCode.Space;
    public float maxDistance;
    public GameObject hitObject;

    bool Swinging;
    float BatSwingPower;

    private void Update()
    {
        ProcessInput();
    }

    private void FixedUpdate()
    {
        Vector3 fwd = Camera.main.transform.TransformDirection(Vector3.forward);

        //if (Physics.Raycast(Camera.main.transform.position, fwd, maxDistance))
        //{
        //    print("There is something in front of the object!");

        //}

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, maxDistance))
        {
            Debug.DrawRay(transform.position, fwd, Color.green);
            if (hit.collider.gameObject.CompareTag("HitObject"))
            {
                Debug.Log(hit.collider.gameObject.name);
                hitObject = hit.collider.gameObject;
            }
        }

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

            if (hitObject != null)
            {
                hitObject.gameObject.GetComponent<ObjectHitScore>().beenHit = true;
                hitObject.gameObject.GetComponent<Rigidbody>().AddForce(player.transform.forward * BatSwingPower, ForceMode.Impulse);
                hitObject.gameObject.GetComponent<ObjectHitScore>().ScoreAndDestroy();
                hitObject = null;
                print("object is none");
            }

            StartCoroutine(Swing());
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