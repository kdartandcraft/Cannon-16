using UnityEngine;
using UnityEngine.InputSystem;

// Cannon script
// Unity Input System Tutorial
public class BallMovement : MonoBehaviour
{
    [SerializeField]
    [Range(10f, 80f)]
    private float angle = 45f;
    [SerializeField]
    GameObject cannon;
    [SerializeField]
    private ParticleSystem muzzleFlash;
    [SerializeField]
    GameObject cannonBallInstance;
    [SerializeField]
    private AudioClip fireCannonClip = null;
    private AudioSource fireCannonSource = null;
    CannonControls cannonControls;

    private void Awake()
    {
        cannonControls = new CannonControls();
        cannonControls.Cannon.Fire.started += Context => OnFire();
    }

    private void Start()
    {
        fireCannonSource = GetComponent<AudioSource>();

        if (fireCannonSource == null)
        {
            Debug.Log("Source is null");
        }
        else
        {
            fireCannonSource.clip = fireCannonClip;
        }
    }

    private void OnMuzzleFlash()
    {
        if (Mouse.current.position.ReadValue() != Vector2.zero)
        {
            muzzleFlash.Play();
        }
    }

    void FireCannonAudio()
    {
        if (Mouse.current.position.ReadValue() != Vector2.zero)
        {
            fireCannonSource.Play();
        }
    }

    private void OnEnable()
    {
        cannonControls.Cannon.Enable();
    }

    private void OnDisable()
    {
        cannonControls.Cannon.Disable();
    }

    void OnFire()
    {
         Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                FireCannonAtPoint(hitInfo.point);

                OnMuzzleFlash();
                FireCannonAudio();
            }
     }

    private void FireCannonAtPoint(Vector3 point)
    {
        var velocity = BallisticVelocity(point, angle);
        Debug.Log("Firing at " + point + " velocity " + velocity);

        cannonBallInstance = PoolManager.Instance.RequestCannonBall();

        if (cannonBallInstance != null)
        {
            cannonBallInstance.transform.position = cannon.transform.position;
            cannonBallInstance.transform.rotation = cannon.transform.rotation;
            cannonBallInstance.SetActive(true);
        }

        Vector3 position = transform.position;
        cannonBallInstance.GetComponent<Rigidbody>().transform.position = position;
        cannonBallInstance.GetComponent<Rigidbody>().velocity = velocity;
     }

    private Vector3 BallisticVelocity(Vector3 destination, float angle)
    {
        Vector3 dir = destination - transform.position; // get Target Direction
        float height = dir.y; // get height difference
        dir.y = 0; // retain only the horizontal difference
        float dist = dir.magnitude; // get horizontal direction
        float a = angle * Mathf.Deg2Rad; // Convert angle to radians
        dir.y = dist * Mathf.Tan(a); // set dir to the elevation angle.
        dist += height / Mathf.Tan(a); // Correction for small height differences

        // Calculate the velocity magnitude
        float velocity = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * dir.normalized; // Return a normalized vector.
    }
}
