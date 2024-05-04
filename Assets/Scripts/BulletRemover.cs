using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _bulletPool;

    private void Awake()
    {
        if (FindObjectOfType<EnemyBulletsSpawner>().TryGetComponent(out ObjectPool pool))
            _bulletPool = pool;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            _bulletPool.PutObject(bullet.gameObject);
        }
    }
}
