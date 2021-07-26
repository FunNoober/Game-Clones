using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float damage;
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        StartCoroutine(DestroyBullet());
    }

    
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(4);
        Destroy(this.gameObject);
    }
}
