using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private float _bulletsLifeTime;

    public void Shoot()
    {
        GameObject bullet = _pool.GetObject();

        bullet.SetActive(true);
        bullet.transform.position = transform.position + transform.right;
        bullet.transform.rotation = transform.rotation;

        StartCoroutine(BulletDestroy(bullet));
    }

    private IEnumerator BulletDestroy(GameObject bullet)
    {
        float latency = 1f;
        WaitForSeconds wait = new WaitForSeconds(latency);
        float timeLeft = _bulletsLifeTime;

        while (timeLeft > latency)
        {
            timeLeft -= latency;
            yield return wait;
        }

        _pool.PutObject(bullet);
    }
}
