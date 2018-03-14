using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject target;

    public float stunTime;
    public float minDistance; //For hitting/ detection area.

    NavMeshAgent navAgent;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {

        if(target != null)
        {
            transform.LookAt(target.transform);
            float dst = Vector3.Distance(target.transform.position, transform.position);

            if(dst > minDistance)
            {
                navAgent.SetDestination(target.transform.position);
            }
            navAgent.stoppingDistance = minDistance;

            //if(dst <= minDistance)
            //{
            //  CapturePlayer();
            //}
        }
    }

    void CapturePlayer()
    {

    }

    public void Stunned()
    {
        print("ENEMY STUNNED! RUN!!!!");
        navAgent.isStopped = true;
        StartCoroutine(StunTimer());
    }

    IEnumerator StunTimer()
    {
        yield return new WaitForSeconds(stunTime);
        navAgent.isStopped = false;
        yield break;
    }
}
