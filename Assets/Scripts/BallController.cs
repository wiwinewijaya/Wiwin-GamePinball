using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Public Variables
    public float maxSpeed;

    // Private Variables
    private Rigidbody rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rig.velocity.magnitude > maxSpeed)
        { 
            rig.velocity = rig.velocity.normalized * maxSpeed;
        }
    }
}