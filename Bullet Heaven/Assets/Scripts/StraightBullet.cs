using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bullet with straight movement (going up in y axis)
public class StraightBullet : MonoBehaviour {

    [SerializeField]
    private float _speed;
    private Rigidbody2D _rb;

	private void Awake ()
    {
        _rb = GetComponent<Rigidbody2D>();
	}
	
	private void Update ()
    {
        _rb.velocity = Vector2.up * _speed;
	}

}
