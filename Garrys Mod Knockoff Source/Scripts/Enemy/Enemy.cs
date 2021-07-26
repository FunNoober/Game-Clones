using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public Transform shootPoint;
    public NavMeshAgent agent;
    public GameObject bullet;
    public bool alreadyAttacked;
    public float fireDelay;

    public float visionRange, attackRange;
    private bool playerInAttack, playerInSight;

    public LayerMask playerMask;

    public float maxHealth = 15f;
    public float currentHealth = 15f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, visionRange, playerMask);
        playerInAttack = Physics.CheckSphere(transform.position, attackRange, playerMask);
        
        if (playerInSight && !playerInAttack) Chase();
        if (playerInAttack && playerInSight) Attack();
    }

    void Idle()
    {

    }

    void Attack()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player.transform.position);

        if(!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(bullet, shootPoint.position, shootPoint.rotation).GetComponent<Rigidbody>();
            rb.AddForce(shootPoint.forward * 1000, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), fireDelay);
        }
    }

    void Chase()
    {
        agent.SetDestination(player.transform.position);
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
            Die();
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
