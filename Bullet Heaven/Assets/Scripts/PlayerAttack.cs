using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    [SerializeField]
    private ObjectPooler _bulletPool;

    // Needs to be placed in the settings, or so.
    [SerializeField]
    private bool _autoFire;
    private float _fireRate;
    private float _nextFire;

    private void Awake()
    {
        _fireRate = 0.15f;
        _nextFire = 0;
    }

    void Update ()
    {
        if (!_autoFire && Input.GetMouseButtonDown(0))
        {
            Fire();
        }

        if (_autoFire && Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            Fire();
        }
	}

    private void Fire( )
    {
        // The first child of the player is the bullet start position
        Vector2 startPosition = transform.GetChild(0).position;
        GameObject bullet = _bulletPool.GetPooledObject();
        bullet.transform.position = startPosition;
        bullet.SetActive(true);
    }
}
