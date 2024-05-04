using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _delay;

    private ObjectPool _pool;

    private void OnEnable()
    {
        if (FindObjectOfType<EnemyBulletsSpawner>().TryGetComponent(out ObjectPool pool))
        {
            _pool = pool;
            StartCoroutine(BulletsShoot());
        }
    }

    private IEnumerator BulletsShoot()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            GameObject bullet = _pool.GetObject();

            bullet.SetActive(true);
            bullet.transform.position = transform.position;

            yield return wait;
        }
    }
}
