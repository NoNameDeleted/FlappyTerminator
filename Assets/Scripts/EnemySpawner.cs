using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private Transform _enemyContainer;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    public void Reset()
    {
        _pool.Reset();

        while (_enemyContainer.childCount > 0)
            DestroyImmediate(_enemyContainer.GetChild(0).gameObject);
    }

    private IEnumerator SpawnEnemies()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        GameObject enemy = _pool.GetObject();

        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
