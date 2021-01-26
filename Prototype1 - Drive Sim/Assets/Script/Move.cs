using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Access Modifier, Data Type, Name
    public float speed = 5.0f;

    public float hInput;

    public float zInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       hInput = Input.GetAxis("Horizontal");
       zInput = Input.GetAxis("Vertical");
       transform.Translate(Vector3.forward *Time.deltaTime * speed * zInput); 
       transform.Translate(Vector3.right *Time.deltaTime * speed * hInput);
    }
}
