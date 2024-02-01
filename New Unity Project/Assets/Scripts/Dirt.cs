using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour
{

    public GameObject hiteffect;
    public float damageToDeal;
    public void Update()
    {
        Physics2D.IgnoreLayerCollision(8, 9);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<TirtleBehavior>().TakeDamage(damageToDeal);
        }

        GameObject effect = Instantiate(hiteffect, collision.gameObject.transform.position, Quaternion.identity);
        Destroy(effect,1f);
        Destroy(gameObject);
    }
}
