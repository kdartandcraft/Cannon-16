using System.Collections.Generic;
using UnityEngine;

// CannonBall Pool script in hierarchy
public class CannonBallPool2 : MonoBehaviour
{
    public static CannonBallPool2 SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject cannonball;

        for (int i = 0; i < amountToPool; i++)
        {
            cannonball = Instantiate(objectToPool);
            cannonball.SetActive(false);
            pooledObjects.Add(cannonball);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}


