using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    // to be able to tell when the object is enabled
    // Will notify unity when the object is active = true
    private void OnEnable()
    {
        // Pass in a method name and seconds
        Invoke(nameof(SetActiveFalse), 1f);
    }

    void SetActiveFalse()
    {
        this.gameObject.SetActive(false);
    }
}
