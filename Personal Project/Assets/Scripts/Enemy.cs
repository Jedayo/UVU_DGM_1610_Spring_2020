using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized; // Finds player position and subtracts from own position

        enemyRb.AddForce(lookDirection * speed); // Moves the enemy towards the player

        // if (transform.position.y < -10) { // Condition to destroy enemy if it falls off the edge
            // Destroy(gameObject);
    }
}
