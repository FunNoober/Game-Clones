using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float startingHealth = 100f;
    public float currentHealth = 100f;
    void Start()
    {
        currentHealth = startingHealth;
    }

    
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
    }
}
