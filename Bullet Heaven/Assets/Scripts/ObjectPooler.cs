using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    [SerializeField]
    private GameObject _pooledObject;
    [SerializeField]
    private int _pooledAmount;

    private List<GameObject> pooledObjects;

    //Creates list of pooled objects and fills the list until it meets the pooledAmount
    private void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < _pooledAmount; i++)
        {
            GameObject obj = Instantiate(_pooledObject);
            obj.transform.SetParent(gameObject.transform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    //If object is inactive, retrieve object. If there isn't an inactive game object, a new one will be instantiated.
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        GameObject obj = Instantiate(_pooledObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}
