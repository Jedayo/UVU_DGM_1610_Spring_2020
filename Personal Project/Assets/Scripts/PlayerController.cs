using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    float zInput;
    float hInput;
    public float speed = 15.0f; 
    public float zRange = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
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

        // Player input
        zInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");

        // Player movement
        transform.Translate(Vector3.right * hInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * zInput * Time.deltaTime * speed);
    }
}
