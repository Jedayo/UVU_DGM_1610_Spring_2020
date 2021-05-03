using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    float zInput;
    float hInput;
    public float speed = 30.0f; 
    public float zRange = 12.0f;
    public bool hasPowerup = false;
    private bool gameOver = false;
    public GameObject character;
    public GameObject projectilePrefab;
    private Animator playerAnim;
    

    // public GameObject powerupIndicator;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = character.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Player constraint condition statements
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        if (transform.position.x < -zRange)
        {
            transform.position = new Vector3(-zRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > zRange)
        {
            transform.position = new Vector3(zRange, transform.position.y, transform.position.z);
        }

        // Player input
        zInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");

        // Player movement
        transform.Translate(Vector3.right * hInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * zInput * Time.deltaTime * speed);

        if(Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            //Launch the projectile (Instantiate(what, where, rotation))
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other) { // Checks if player collides with a trigger
        if (other.CompareTag("Powerup")) { // If the the trigger has the powerup tag
            hasPowerup = true; 
            // powerupIndicator.gameObject.SetActive(true); // Turns on the powerup indicator
            Destroy(other.gameObject); // Destroys the powerup
            StartCoroutine(PowerupCountdownRoutine()); // Starts the timer to when the buff ends
        }
        
        else if (other.CompareTag("Enemy") && hasPowerup) {
            Destroy(other.gameObject);
            Debug.Log("Get smashed");
        }

        else if (other.CompareTag("Enemy")) {
            gameOver = true;
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            speed = 0;
        }
    }
    IEnumerator PowerupCountdownRoutine() { // Count method to control buff length
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        // powerupIndicator.gameObject.SetActive(false);
    }
}
