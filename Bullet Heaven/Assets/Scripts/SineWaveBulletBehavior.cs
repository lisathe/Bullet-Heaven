using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWaveBulletBehavior : MonoBehaviour {

    [SerializeField]
    private float _fireRate;

    private ObjectPooler _bulletPool;
    private float _nextFire;


    private void Start()
    {
        _bulletPool = GameObject.FindGameObjectWithTag("SineWaveBulletPool").GetComponent<ObjectPooler>();
    }

    private void Update()
    {
        if (Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            Fire();
        }
    }
    public void Fire()
    {
        // The first child of the enemy is the bullet start position
        Vector2 startPosition = transform.GetChild(0).position;
        GameObject bullet = _bulletPool.GetPooledObject();
        bullet.transform.position = startPosition;
        bullet.SetActive(true);
    }
}
