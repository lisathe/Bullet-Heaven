using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour {

    protected AudioClip _collisionSound;
    protected float _destroyTime;
    protected float _timer;
    protected bool _isPlayer;
    protected bool _isPlayerBullet;

    public virtual void Awake()
    {
        _timer = 0;
        _destroyTime = 1.5f;
    }
	
	public virtual void Update ()
    {
        // If outside of the screen (due time), remove bullet.
        _timer += Time.deltaTime;
        if (_timer >= _destroyTime)
        {
            gameObject.SetActive(false);
            _timer = 0;
        }
	}

    // If the player is hit by the enemy bullet, or the enemy is hit by the player bullet
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isPlayer && !_isPlayerBullet)
        {
            gameObject.SetActive(false);
            //AudioSource.PlayClipAtPoint(_collisionSound, transform.position);
            // Add TakeDamage(player)
        }

        if (!_isPlayer && _isPlayerBullet)
        {

            gameObject.SetActive(false);
            //AudioSource.PlayClipAtPoint(_collisionSound, transform.position);
            //Add TakeDamage(enemy)
        }
    }


}
