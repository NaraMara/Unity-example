using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirtleBehavior : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootingPos;
    public Transform shootDir;
    public float shootDelay;
    public float shootPower;
    public float Health;


    private float  nextShootTime;
    private Animator animator;
    Vector2 direction;
    private void Awake()
    {
        direction.x = shootDir.position.x - shootingPos.position.x;
        direction.y = shootDir.position.y - shootingPos.position.y;
        direction.Normalize();
        animator = gameObject.GetComponent<Animator>();

    }
    private bool ShouldShoot()
    {
        return Time.time >= nextShootTime;
    }
    private void Shoot()
    {
        nextShootTime = Time.time + shootDelay;

        GameObject bullet = Instantiate(bulletPrefab, shootingPos.transform.position, shootingPos.transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * shootPower, ForceMode2D.Impulse);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldShoot())
        {
            StartCoroutine(WaitForSeconds());
            Shoot();
        }
    }

    private IEnumerator WaitForSeconds()
    {
        animator.Play("Shoot");
        yield return new WaitForSeconds(0.3f);
        Shoot();
    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
        if(Health<0)
        {
            Death();
        }
    }
    private void Death()
    {
        //play death animation
        Destroy(gameObject);
    }
}
