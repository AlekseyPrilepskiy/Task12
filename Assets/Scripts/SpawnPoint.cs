using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private TargetBehavior _target;

    public void CreateEnemy()
    {
        EnemyBehavior enemy = _enemyPool.GetEnemy();
        enemy.transform.position = transform.position;
        enemy.SetTarget(_target);
    }
}
