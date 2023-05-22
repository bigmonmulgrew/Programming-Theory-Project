using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] int minAttackTime;
    [SerializeField] int maxAttackTime;

    int minDamage = 5;
    int maxDamage = 20;

    int minHealAmount;
    int maxHealAmount;

    Player target;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        target = FindObjectOfType<Player>();
        StartCoroutine(AttackPlayer());
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AttackPlayer()
    {
        while (FindObjectsOfType <Player>().Length > 0)
        {
            yield return new WaitForSeconds(Random.Range(minAttackTime, maxAttackTime));
            target.LoseHealth(Random.Range(minDamage, maxDamage));
        }
    }

    IEnumerator Heal()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            HealHealth(Random.Range(minHealAmount,  maxHealAmount));
        }
    }
}
