using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] float _spawnTime = 2f;

    private int _spawnPointsCount;
    private WaitForSeconds _waitForSeconds;

    void Start()
    {
        _spawnPointsCount = _spawnPoints.Count;
        _waitForSeconds = new WaitForSeconds(_spawnTime);
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (enabled)
        {
            yield return _waitForSeconds;

            EnemyBehavior enemy = _enemyPool.GetEnemy();
            enemy.transform.position = _spawnPoints[UnityEngine.Random.Range(0, _spawnPointsCount)].transform.position;

            Vector3 direction = UnityEngine.Random.onUnitSphere;
            direction.y = 0;
            direction.Normalize();

            enemy.SetDirection(direction);
        }
    }
}
