using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    [SerializeField] private Transform[] _pathPoints;
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _reachThreshold = 0.1f;

    private int _currentTargetIndex = 0;

    private void Update()
    {
        Transform target = _pathPoints[_currentTargetIndex];
        Vector3 direction = (target.position - transform.position).normalized;

        transform.position += direction * _moveSpeed * Time.deltaTime;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < _reachThreshold)
        {
            _currentTargetIndex = (_currentTargetIndex + 1) % _pathPoints.Length;
        }
    }
}

