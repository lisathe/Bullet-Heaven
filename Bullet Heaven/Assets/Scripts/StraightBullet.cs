using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bullet with straight movement (going up in y axis)
public class StraightBullet : Bullet {

    [SerializeField]
    private bool _playerShot;
    [SerializeField]
    private float _speed;
    private Rigidbody2D _rb;


	public override void Awake ()
    {
        _rb = GetComponent<Rigidbody2D>();
        _isPlayer = _playerShot;
        base.Awake();
	}
	
    // If the enemy shoots the bullet down, player shoots up
	public override void Update ()
    {
        if (_isPlayer)
        {
            _rb.velocity = Vector2.up * _speed;
        }
        else
        {
            _rb.velocity = Vector2.down * _speed;
        }
        base.Update();
	}

}
