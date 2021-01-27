﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Access Modifier, Data Type, Name
    private float speed = 30.0f;

    private float turnSpeed = 40.0f;

    private float hInput;

    private float fInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Gathers the inputs for the controls
       hInput = Input.GetAxis("Horizontal");
       fInput = Input.GetAxis("Vertical");

       // Makes the vehicle go forward and back
       transform.Translate(Vector3.forward * Time.deltaTime * speed * fInput);

       // Makes the vehicle go left and right
       transform.Rotate(Vector3.up, turnSpeed * hInput * Time.deltaTime);
    }
}
