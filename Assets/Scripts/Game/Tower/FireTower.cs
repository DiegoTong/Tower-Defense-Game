using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : Tower
{
    public GameObject fireParticlesPrefab;

    protected override void AttackEnemy()
    {
        base.AttackEnemy();

        // Create new particles
        GameObject particles = (GameObject)Instantiate(fireParticlesPrefab, transform.position + new Vector3(0, .5f),
            fireParticlesPrefab.transform.rotation);
        particles.transform.localScale *= aggroRadius / 10f; // Scale fire particle radius with the aggro radius

        // Damage all enemies in range
        foreach (Enemy enemy in EnemyManager.Instance.GetEnemiesInRange(transform.position, aggroRadius))
        {
            enemy.TakeDamage(attackPower);
        }
    }
}
