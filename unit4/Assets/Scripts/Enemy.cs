using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 3.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);
    }
}
