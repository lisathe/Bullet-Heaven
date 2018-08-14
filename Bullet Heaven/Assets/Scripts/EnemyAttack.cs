using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    [SerializeField]
    private ObjectPooler _bulletPool;

    private float _fireRate;
    private float _nextFire;

    private void Awake()
    {
        _fireRate = 0.8f;
        _nextFire = 0;
    }

    void Update()
    {
        if (Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            Fire(_bulletPool);
        }
    }

    private void Fire(ObjectPooler pool)
    {
        // The first child of the player is the bullet start position
        Vector2 startPosition = transform.GetChild(0).position;
        GameObject bullet = pool.GetPooledObject();
        bullet.transform.position = startPosition;
        bullet.SetActive(true);
    }
}
