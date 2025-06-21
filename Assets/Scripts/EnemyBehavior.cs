using System;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour, IColorChangeNotifier
{
    private Mover _mover;
    private Vector3 _direction;
    private bool _isAlive;

    public event Action<EnemyBehavior> Crashed;
    public event Action StatusChanged;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void OnEnable()
    {
        _isAlive = true;
    }

    private void FixedUpdate()
    {
        if (_isAlive)
        {
            _mover.Move(_direction);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isAlive == true && collision.gameObject.TryGetComponent<Wall>(out _))
        {
            Crashed?.Invoke(this);
            StatusChanged?.Invoke();
            _isAlive = false;
        }
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
}
