using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] int startingHealth;
    [SerializeField] Color color;

    int currentHealth;

    #region Properties
    public int CurrentHealth { get; private set; }
    #endregion

    protected virtual void Start()
    {
        GetComponent<MeshRenderer>().material.color = color;
        currentHealth = startingHealth;
    }
    public virtual void LoseHealth()
    {
        currentHealth--;
        Debug.Log( name + " health: " + currentHealth);
    }

    public virtual void LoseHealth(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) Destroy(gameObject);
        Debug.Log(name + " health: " + currentHealth);
    }

    protected virtual void Healhealth()
    {
        currentHealth++;
        Debug.Log(name + " health: " + currentHealth);
    }
    protected virtual void HealHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > startingHealth) currentHealth = startingHealth;
        Debug.Log(name + " health: " + currentHealth);
    }
}
