using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject _cannonBallPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))

        {
            // Communicate with the objectpool system
            // Request cannonBall
            GameObject cannonBall = PoolManager.Instance.RequestCannonBall();

            // Enter the location to spawn the cannonBall(in the cannon)
            cannonBall.transform.position = Vector3.zero;
        }
    }
}
