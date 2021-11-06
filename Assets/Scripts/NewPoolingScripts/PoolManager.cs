using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // Creat Singleton for easy access
    // Create a list of bullets using the bullet prefab

    private static PoolManager _instance;

    public static PoolManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("PoolManager is NULL");
            }
            return _instance;
        }
    }
    // To create a container for the cannonBall objects
    [SerializeField]
    private GameObject _cannonBallContainer;
    [SerializeField]
    private GameObject _cannonBallPrefab;
    [SerializeField]
    private List<GameObject> _cannonBallPool;

    // Initialize _instance
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        // to initialize the list
        _cannonBallPool = GenerateCannonBalls(10);
    }

    // List to be returned
    // Generate a list of cannonBallprefabs
    // Use for loop to repeat adding connoBallPrefab to the list
    List<GameObject> GenerateCannonBalls(int amountOfCannonBalls)
    {
        for (int i = 0; i < amountOfCannonBalls; i++)
        {
            GameObject cannonBall = Instantiate(_cannonBallPrefab);

            // Make the cannonBall object a child of PoolManager
            cannonBall.transform.parent = _cannonBallContainer.transform;

            // Set active to false
            cannonBall.SetActive(false);

            // Add the cannonBall objects
            _cannonBallPool.Add(cannonBall);
        }
        return _cannonBallPool;
    }

    // To request a cannonBall
    public GameObject RequestCannonBall()
    {
        foreach (var cannonBall in _cannonBallPool)
        {
            if (cannonBall.activeInHierarchy == false)
            {
                // if CannonBall is available
                cannonBall.SetActive(true);
                return cannonBall;
            }
        }

        GameObject newCannonBall = Instantiate(_cannonBallPrefab);

        newCannonBall.transform.parent = _cannonBallContainer.transform;

        _cannonBallPool.Add(newCannonBall);

        return newCannonBall;
    }
}
