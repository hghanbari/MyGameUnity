using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Destroy an object out of bounds
    void Update()
    {
        if (transform.position.x > 55)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < -10) 
        {
            Destroy(gameObject); 
        }
    }
}
