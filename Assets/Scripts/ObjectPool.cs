using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private GameObject[] _prefabs;

    private Queue<GameObject> _pool;

    private IEnumerable<GameObject> PooledObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<GameObject>();
    }

    public GameObject GetObject()
    {
        if (_pool.Count == 0)
        {
            var enemy = Instantiate(_prefabs[Random.Range(0, _prefabs.Length)]);
            enemy.transform.parent = _container;

            return enemy;
        }

        return _pool.Dequeue();
    }

    public void PutObject(GameObject enemy)
    {
        _pool.Enqueue(enemy);
        enemy.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}
