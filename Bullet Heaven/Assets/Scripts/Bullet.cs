using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour {

    protected AudioClip _collisionSound;
    protected float _destroyTime;
    protected float _timer;
    protected bool _isPlayerBullet;
    protected int _damage;

    public virtual void Awake()
    {
        _timer = 0;
        _destroyTime = 2f;
    }
	
	public virtual void Update ()
    {
        // If outside of the screen (due time), remove bullet.
        _timer += Time.deltaTime;
        if (_timer >= _destroyTime)
        {
            _timer = 0;
            gameObject.SetActive(false);

        }
	}

    // If the player is hit by the enemy bullet, or the enemy is hit by the player bullet
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_isPlayerBullet)
        {
            gameObject.SetActive(false);
            //AudioSource.PlayClipAtPoint(_collisionSound, transform.position);
            collision.gameObject.GetComponent<Health>().TakeDamage(_damage, _isPlayerBullet);
        }

        if (collision.CompareTag("Enemy") && _isPlayerBullet)
        {

            gameObject.SetActive(false);
            //AudioSource.PlayClipAtPoint(_collisionSound, transform.position);
            collision.gameObject.GetComponent<Health>().TakeDamage(_damage, _isPlayerBullet);
        }
    }


}
