using UnityEngine;

public class EnemyRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _enemyPool;
    [SerializeField] private int _enemyCost;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void Awake()
    {
        if (FindObjectOfType<EnemySpawner>().TryGetComponent(out ObjectPool pool))
            _enemyPool = pool;

        if (FindObjectOfType<Ship>().TryGetComponent(out ScoreCounter counter))
            _scoreCounter = counter;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.StopAllCoroutines();
            _enemyPool.PutObject(enemy.gameObject);
            _scoreCounter.Add(_enemyCost);
        }
    }
}
