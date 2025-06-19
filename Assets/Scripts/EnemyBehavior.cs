using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Mover _mover;

    private Vector3 _direction;

    private bool _isAlive;

    public event Action<EnemyBehavior> Crashed;

    private void Start()
    {
        _mover = GetComponent<Mover>();
    }

    private void OnEnable()
    {
        _isAlive = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isAlive == true && collision.gameObject.TryGetComponent<Wall>(out _))
        {
            Crashed?.Invoke(this);
            _isAlive = false;
        }
    }

    public void FixedUpdate()
    {
        if (_isAlive)
        {
            _mover.Move(_direction);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
}
