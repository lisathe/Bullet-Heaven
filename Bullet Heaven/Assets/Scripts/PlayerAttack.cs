using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    [SerializeField]
    private GameObject _playerBullet;

    // Needs to be placed in the settings, or so.
    [SerializeField]
    private bool _autoFire;
	
	// Update is called once per frame
	void Update ()
    {
        if (!_autoFire && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed left mouse click");
            Fire();
        }

        if (_autoFire) // And add timer with fire rate
        {
            //Fire();
        }
	}

    private void Fire()
    {
        // The first child of the player is the bullet start position
        Vector2 startPosition = transform.GetChild(0).position;
        Instantiate(_playerBullet, startPosition, transform.rotation);
    }
}
