using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    int damage = 20;
    int healAmount = 10;
    [SerializeField] int cooldown = 3;
    bool onCooldown = false;
    Enemy target;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        target = FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!onCooldown) Attack();   
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            target.LoseHealth(damage);
            StartCoroutine(CooldownTimer());
        }

    }
    IEnumerator CooldownTimer()
    {
        onCooldown = true;
        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
    }

    IEnumerator Heal()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            HealHealth(healAmount);
        }
    }
}
