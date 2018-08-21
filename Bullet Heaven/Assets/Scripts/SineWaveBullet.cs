using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For now, sine wave bullet will always be an enemy bullet
// It seems rather unhandy to use as player bullet...
public class SineWaveBullet : Bullet
{
    [SerializeField]
    private float _speed;
    private Rigidbody2D _rb;

    [SerializeField]
    private int _dmgBullet;

    [SerializeField]
    // Speed of the sine wave
    private float _frequency;

    [SerializeField]
    //Size of the sine wave
    private float _magnitude;


    public override void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _damage = _dmgBullet;
        base.Awake();
        _destroyTime = 100f;
        _isPlayerBullet = false;
    }

    //Bullet goes down, while moving left to right (in a sine wave)
    public override void Update()
    {
        _rb.velocity = new Vector2(Mathf.Sin(Time.time * _frequency) * _magnitude, -1 * _speed);
        base.Update();
    }
}
