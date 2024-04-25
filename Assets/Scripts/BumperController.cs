using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    // Public Variables
    public float multiplier;
    public Color color;

    //Private Variables
    private Collider ball;
    private Renderer bumperRenderer;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Doing this so I don't have to drag and drop the ball into the bumper everytime I add one.
        // Not sure if this is too expensive or not.
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Collider>();

        // This doesn't do anything right now because of the animation messing with the color.
        bumperRenderer = GetComponent<Renderer>();
        bumperRenderer.material.color = color;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == ball)
        {
            Rigidbody ballRB = ball.GetComponent<Rigidbody>();
            ballRB.velocity *= multiplier;

            // Wondering if there's a way to get this using GUI fromt the animator controller?
            animator.SetTrigger("Hit");
        }
    }
}
