using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Mover : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody _rigidbody;
    private float _rotationSpeed = 10f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnDisable()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }

    public void Move(TargetBehavior target)
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;

        Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * _rotationSpeed);
        _rigidbody.MovePosition(_rigidbody.position + direction.normalized * speed * Time.fixedDeltaTime);
    }
}