using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//Add a Rigidbody2D if the game object doesn't already have one and that it can't be removed wihou removing the script
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    //Variables
    public Transform target;
    public float speed = 5f;
    public float turnSpeed = 1f;
    public float maxVelocity = 7f;
    [HideInInspector]
    public float startDelay;
    private Rigidbody2D rb;
    
    void Start()
    {
        //Assigns gameObject's Rigidbody to rb variale
        rb = GetComponent<Rigidbody2D>();

        startDelay = 0f;
    }

    void FixedUpdate()
    {
        // Adds a small delay before movemen starting at the start of a level 
        if (startDelay < 50) startDelay++;

        //Gets horizontal input axis
        float xAxis = Input.GetAxis("Horizontal");

        //Calls Thrust and Rotate methods after short delay
        if (startDelay == 50)
        {
            Thrust(speed);
            Rotate(transform, xAxis * -turnSpeed);
        }
    }

    //Add velocity to rigidbody to move player fowards
    public void Thrust(float amount)
    {
        Vector2 force = transform.up * amount;

        rb.AddForce(force);
    }

    //Clamps rigidbody's velociy so that i doesn't increase infinitly
    private void ClampVelocity()
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);

        rb.velocity = new Vector2(x, y);
    }

    //Rotates player ship to change direction
    private void Rotate(Transform transform, float amount)
    {
        transform.Rotate(0, 0, amount);
    }

}
