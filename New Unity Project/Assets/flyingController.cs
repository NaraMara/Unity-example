using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingController : MonoBehaviour
{

    public Transform RespawnPoint;
    public Transform ShootinPoint;
    public GameObject BulletPrefab;
    public float BulletForce = 20f;

    [SerializeField] public float moveSpeed;
    private Rigidbody2D rigidbody2d;

    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
     
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            

            rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);

        }else


        if (Input.GetKey(KeyCode.D))
        {



            rigidbody2d.velocity = new Vector2(moveSpeed, rigidbody2d.velocity.y);

        }else

        if (Input.GetKey(KeyCode.W))
        {


            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, moveSpeed);

        }else

        if (Input.GetKey(KeyCode.S))
        {



            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, -moveSpeed);

        }
        else
        {
            rigidbody2d.velocity = new Vector2(0, 0);

        }

        if(Input.GetKeyDown(KeyCode.Space ))
        {
            Shoot();
        }


           
    }


    private void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, ShootinPoint.transform.position, ShootinPoint.transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.right * BulletForce, ForceMode2D.Impulse);
    } 

}
