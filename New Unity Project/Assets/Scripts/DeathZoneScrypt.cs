using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneScrypt : MonoBehaviour
{
   
    [SerializeField]  Transform respawnPoint;
    

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
            col.transform.position = respawnPoint.position;
    }
}
