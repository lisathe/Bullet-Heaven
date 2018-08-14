using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLineMovement : MonoBehaviour {

    [SerializeField]
    private float _speed;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update ()
    {
        _rb.velocity = Vector2.down * _speed;

	}
}
