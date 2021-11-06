using TMPro;
using UnityEngine;

// Target script
public class Count : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI targetText;
    [SerializeField]
    ParticleSystem explosionParticle;
    AudioSource explosionSound;
    private int CountHits = 0;

    void Start()
    {
        explosionSound = GetComponent<AudioSource>();

        CountHits = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cannonball"))
        {
            explosionParticle.Play();
            explosionSound.Play();

            Debug.Log("Target hit");
            CountHits += 1;
            targetText.text = "Hits: " + CountHits;

            ScoreManager.Instance.AddScore();
        }
    }
}
