using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject ShootingPos;
    public GameObject DirtPrefab;
    public GameObject Cursor;
    public float  BulletForce=20f;
    public Camera cam;
    public NewCharacterController controller;
    public Animator animator;
    Vector2 mousePos;
    Vector2 mouseDirection;

   private bool ammo=false;
    

    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            if(ammo)
            {
                mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
                mouseDirection.x = mousePos.x - ShootingPos.transform.position.x;
                mouseDirection.y = mousePos.y - ShootingPos.transform.position.y;
                mouseDirection.Normalize();

                Shoot();
            }
        }

        if(Input.GetKeyDown(KeyCode.Mouse1)&& !ammo)
        {
            
            Reload();
        }

       

    }
    
     private IEnumerator WaitForSeconds()
    {
        controller.enabled = false;
        animator.Play("summon dirt");
        yield return new WaitForSeconds(0.6f);
        ShootingPos.GetComponent<SpriteRenderer>().enabled = true;
        controller.enabled = true;
    }
    private void Reload()
    {
        //freeze player
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        
        // play animation and increase ammo 
        
        StartCoroutine(WaitForSeconds());


        ammo = true;
        //unfreeze player
 
        
        

    }
    private void Shoot( )
    {
        
        GameObject bullet = Instantiate(DirtPrefab, ShootingPos.transform.position, ShootingPos.transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(mouseDirection * BulletForce, ForceMode2D.Impulse);
        ammo = false;
        ShootingPos.GetComponent<SpriteRenderer>().enabled = false;

    }
}
