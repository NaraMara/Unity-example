using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowingCursor : MonoBehaviour
{
     
    private Rigidbody2D rb;
    public  Camera cam;

    private Vector2 mousePos;
    private Vector2 mouseDirection;

    public float speed;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseDirection.x = mousePos.x - transform.position.x;
        mouseDirection.y = mousePos.y - transform.position.y;
        mouseDirection.Normalize();

        rb.velocity = mouseDirection* speed;



    }
}
