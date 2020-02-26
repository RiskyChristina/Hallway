using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public Transform target;
    public Transform resetpoint;
    public Transform resetpoint2;
    public Transform guard;
    UnityEngine.AI.NavMeshAgent agent;
    public bool Alertstatus = true;
    public float Monitoring = 1;

    private AudioManager audioManager;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        audioManager = AudioManager.instance;
    }

    void Update()
    {
        if (Alertstatus == true)
        {
            agent.SetDestination(target.position);
            Monitoring = 0;
            audioManager.PlaySound("alertSound");
        }
        if (Alertstatus == false && Monitoring == 1)
        {
            agent.SetDestination(resetpoint.position);
            if (resetpoint.position == guard.position)
            {
                Monitoring = 2;
            }
        }
        if (Alertstatus == false && Monitoring == 2)
        {
            agent.SetDestination(resetpoint2.position);
            if (resetpoint2.position == guard.position)
            {
                Monitoring = 1;
            }
        }
    }
}
