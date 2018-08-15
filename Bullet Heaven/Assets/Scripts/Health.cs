using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [Tooltip("Health points of this object")]
    [SerializeField]
    private int _hp;

    public void TakeDamage(int damage, bool isPlayer)
    {
        if (_hp >= 1)
        {
            _hp -= damage;
        }

        else
        {
            if (isPlayer)
            {
                // Gameover
                gameObject.SetActive(false);
            }
            else
            {
                //Enemy is defeated
                gameObject.SetActive(false);
            }
        }
    }
}
