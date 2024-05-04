using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody2d;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private readonly string Jump = nameof(Jump);

    private void Start()
    {
        _startPosition = transform.position;
        _rigidbody2d = GetComponent<Rigidbody2D>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void Update()
    {
        if (Input.GetAxisRaw(Jump) > 0)
        {
            _rigidbody2d.velocity = new Vector2(_speed, _tapForce);
            transform.rotation = _maxRotation;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _rigidbody2d.velocity = Vector2.zero;
    }
}
