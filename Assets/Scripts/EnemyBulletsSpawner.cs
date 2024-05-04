using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class EnemyBulletsSpawner : MonoBehaviour
{
    [SerializeField] private Transform _enemyBulletsContainer;

    private ObjectPool _pool;

    private void Awake()
    {
        _pool = GetComponent<ObjectPool>();
    }

    public void Reset()
    {
        _pool.Reset();

        while (_enemyBulletsContainer.childCount > 0)
            DestroyImmediate(_enemyBulletsContainer.GetChild(0).gameObject);
    }
}
