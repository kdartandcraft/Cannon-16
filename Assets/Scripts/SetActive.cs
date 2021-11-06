using UnityEngine;

// Cannonball script
public class SetActive : MonoBehaviour
{
    
    private void Start()
    {
         SetColor();
    }

    void SetColor()
    {
        this.GetComponent<Renderer>().material.color = ColorManager.Instance.BallColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
             Invoke(nameof(SetActiveFalse), 0f);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            Invoke(nameof(SetActiveFalse), 0f);
        }
    }

    void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }

    void SetColor(Color c)
    {
        var colorHandler = GetComponentInChildren<ColorHandler>();
        if (colorHandler != null)
        {
            colorHandler.SetColor(c);
        }
    }
}