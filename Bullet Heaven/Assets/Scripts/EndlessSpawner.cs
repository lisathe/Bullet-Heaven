using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessSpawner : MonoBehaviour {


    //Enemy object pools
    [SerializeField]
    private List <ObjectPooler> _enemies;

    //Spawn Range
    [SerializeField]
    private Transform _minSpawnPos, _maxSpawnPos;
    private Vector2 _spawnPosition;

    //Timers
    private float _enemyTimer;
    private float _enemySpawnInterval;
    private float _estimatedPlaytime;

    //Lerp
    private float _enemyStartInterval;
    private float _enemyEndInterval;

	private void Awake ()
    {
        _enemyTimer = 0;
        _enemySpawnInterval = 5f;
        _enemyStartInterval = 5f;
        _enemyEndInterval = 1f;
        _estimatedPlaytime = 300f; // 5 mins
	}
	
	private void Update ()
    {
        if (_enemyTimer < _enemySpawnInterval)
        {
            _enemyTimer += Time.deltaTime;
        }
        else
        {
            _enemyTimer = 0;
            SpawnObject(_enemies[Random.Range(0, _enemies.Count)]);
            _enemySpawnInterval = Mathf.Lerp(_enemyStartInterval, _enemyEndInterval, Time.timeSinceLevelLoad / _estimatedPlaytime);
        }
	}

    // Gameobject with this script attached is on the correct y position. :)
    private void SpawnObject(ObjectPooler pool)
    {
        _spawnPosition = new Vector2(Random.Range(_minSpawnPos.position.x, _maxSpawnPos.position.x),transform.position.y);
        GameObject newObject = pool.GetPooledObject();
        newObject.transform.position = _spawnPosition;
        newObject.SetActive(true);
    }
}
