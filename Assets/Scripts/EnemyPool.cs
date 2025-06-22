using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private EnemyBehavior _enemyPrefab;
    [SerializeField] private int _poolSize = 4;
    [SerializeField] private float _lifeTime = 2f;

    private List<EnemyBehavior> _enemiesPool;

    private void Start()
    {
        _enemiesPool = new List<EnemyBehavior>();

        for (int i = 0; i < _poolSize; i++)
        {
            EnemyBehavior enemy = Instantiate(_enemyPrefab);

            enemy.gameObject.SetActive(false);
            enemy.Crashed += ReturnEnemy;

            _enemiesPool.Add(enemy);
        }
    }

    private void OnDisable()
    {
        foreach (EnemyBehavior enemy in _enemiesPool)
        {
            enemy.Crashed -= ReturnEnemy;
        }
    }

    public EnemyBehavior GetEnemy()
    {
        foreach (EnemyBehavior enemy in _enemiesPool)
        {
            if (enemy.gameObject.activeInHierarchy == false)
            {
                enemy.gameObject.SetActive(true);
                return enemy;
            }
        }

        EnemyBehavior newEnemy = Instantiate(_enemyPrefab);

        newEnemy.gameObject.SetActive(true);
        newEnemy.Crashed += ReturnEnemy;

        _enemiesPool.Add(newEnemy);
        return newEnemy;
    }

    private void ReturnEnemy(EnemyBehavior enemy)
    {
        StartCoroutine(ReturnRoutine(enemy));
    }

    private IEnumerator ReturnRoutine(EnemyBehavior enemy)
    {
        yield return new WaitForSeconds(_lifeTime);

        enemy.gameObject.SetActive(false);
    }
}
