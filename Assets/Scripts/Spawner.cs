using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private float _spawnTime = 2f;

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

            _spawnPoints[UnityEngine.Random.Range(0, _spawnPointsCount)].CreateEnemy();
        }
    }
}
