
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject powerUpIndicator;
    private GameObject focalPoint;
    private Rigidbody playerRb;

    public bool hasPowerUp; //know when the powerup is picked
    public float speed = 5.0f;
    public float powerUpStrenght = 15.0f;
   
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        powerUpIndicator.transform.position = transform.position + new Vector3(0, 0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            powerUpIndicator.gameObject.SetActive(true);
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false; //reset player state to before they picked the powerup
        powerUpIndicator.gameObject.SetActive(false);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position; //enemy current position - player current position

            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrenght, ForceMode.Impulse);
            Debug.Log("Collided with " + collision.gameObject.name +
                " with powerup set to " + hasPowerUp);
        }
    }
}
