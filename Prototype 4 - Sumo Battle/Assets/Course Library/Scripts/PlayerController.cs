using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody playerRb;
    public float speed = 5.0f;
    private GameObject focalPoint;
    public bool hasPowerup = false;
    private float powerupStrength = 15.0f;
    public GameObject powerupIndicator;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical"); // Controls player movement forward and backwards

        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput); 

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0); // Moves the powerup indicator to the ground of player
    }

    private void OnTriggerEnter(Collider other) { // Checks if player collides with a trigger
        if (other.CompareTag("Powerup")) { // If the the trigger has the powerup tag
            hasPowerup = true; 
            powerupIndicator.gameObject.SetActive(true); // Turns on the powerup indicator
            Destroy(other.gameObject); // Destroys the powerup
            StartCoroutine(PowerupCountdownRoutine()); // Starts the timer to when the buff ends
        }
    }

    IEnumerator PowerupCountdownRoutine() { // Count method to control buff length
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision) { // Detects player collision
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup) {

            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position); // Positional variable that finds the position of the enemy after collision

            Debug.Log("Collided with " + collision.gameObject.name
            + " with powerup set to " + hasPowerup);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse); // Amplifies the position of the enemy based on its position after collision
        }
    }
}

