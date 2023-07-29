using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int maxHitPoints = 5;
    int currentHitPoints;

    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    void OnParticleCollision(GameObject other) 
    {
        ProcessHit();
            
    }

    void ProcessHit()
    {
        currentHitPoints--;

        if(currentHitPoints<=0)
        {
            gameObject.SetActive(false);
            enemy.RewardGold();
        }
    }
}
