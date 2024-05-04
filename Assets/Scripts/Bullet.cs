using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _direction;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.right * _direction, Time.deltaTime * _speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ship ship))
        {
            ship.Destroy();
        }
    }
}
