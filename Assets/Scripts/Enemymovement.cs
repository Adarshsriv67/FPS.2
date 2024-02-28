using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemymovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public float health;
    public LayerMask whatIsGrounded, whatIsPlayer;
    public Vector3 walkPoint;
    bool walkPointset;
    public float walkPointRange;
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInattackRange;
    
    private void Awake()
    {
       player=GameObject.Find("Player").transform;
       agent=GetComponent<NavMeshAgent>();
    }

    void Update()
    {
       playerInSightRange=Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
       playerInattackRange=Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
       
       if(!playerInSightRange && !playerInattackRange) Petrolling();
       if(playerInSightRange && !playerInattackRange) ChasePlayer();
       if(playerInSightRange && playerInattackRange) AttackPlayer();
    }

    private void Petrolling()
    {
        if(!walkPointset) SearchWalkPoint();
        if(walkPointset)
        {
            agent.SetDestination(walkPoint);
        }
        Vector3 distanceToWalkPoint= transform.position-walkPoint;

        if(distanceToWalkPoint.magnitude<1f)
        {
            walkPointset=false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ=Random.Range(-walkPointRange, walkPointRange);
        float randomX=Random.Range(-walkPointRange, walkPointRange);

        walkPoint=new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        
        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGrounded))
        walkPointset=true;
    }

    private void ChasePlayer()
    {
       agent.SetDestination(player.position); 
    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        if(!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            alreadyAttacked=true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked=false;
    }

    public void TakeDamage(int damage)
    {
        health-=damage;
        if(health<=0) Invoke(nameof(DestroyEnemy), 0.5f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    
}