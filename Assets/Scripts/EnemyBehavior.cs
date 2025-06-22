using System;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour, IColorChangeNotifier
{
    private TargetBehavior _target;
    private Mover _mover;
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
            _mover.Move(_target);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isAlive == true && (collision.gameObject.TryGetComponent<Wall>(out _) || collision.gameObject.TryGetComponent<TargetBehavior>(out _)))
        {
            Crashed?.Invoke(this);
            StatusChanged?.Invoke();
            _isAlive = false;
        }
    }

    public void SetTarget(TargetBehavior target)
    {
        _target = target;
    }
}
