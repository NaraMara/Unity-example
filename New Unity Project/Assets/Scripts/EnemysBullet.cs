using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysBullet : MonoBehaviour
{

    private void Update()
    {
        Physics2D.IgnoreLayerCollision(11, 12);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<NewCharacterController>().Respawn();
        
        Destroy(gameObject);
    }

    
}
