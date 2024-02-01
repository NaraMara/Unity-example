using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float speedVelocoty;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * speedVelocoty;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
