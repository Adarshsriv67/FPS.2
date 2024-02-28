using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class em : MonoBehaviour
{
    public GameObject Player;
    public float Distance;
    public bool isAngered;
    public NavMeshAgent _agent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Distance=Vector3.Distance(Player.transform.position, this.transform.position);
        if(Distance<=5)
        {
            isAngered=false;
        }
        if(Distance>5f)
        {
            isAngered=false;
        }
        if(isAngered)
        {
            _agent.isStopped=false;
            _agent.SetDestination(Player.transform.position);
        }
        if(!isAngered)
        {
            _agent.isStopped=true;
        }
    }
}
