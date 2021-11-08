using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public float force;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Rigidbody playerRb = other.GetComponent<Rigidbody>(); // получили риджиб боди игрока
        playerRb.AddForce(transform.up * force);
    }
}
