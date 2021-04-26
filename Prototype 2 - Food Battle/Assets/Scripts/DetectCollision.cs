using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {   
        // Destroy the object that script is on
        Destroy(gameObject);
        // Destroy other object that is detected by trigger
        Destroy(other.gameObject);
    }
}
