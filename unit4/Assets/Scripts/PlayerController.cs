using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private GameObject focalPoint;
    private Rigidbody playerRb;

    public bool hasPowerUp; //know when the powerup is picked
    public float speed = 5.0f;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup")){
            hasPowerUp = true;
            Destroy(other.gameObject);
        }
    }
}
