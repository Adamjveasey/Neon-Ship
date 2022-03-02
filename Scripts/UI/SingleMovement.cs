using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Movement script for display ship in main menu 
// with single movement command of spinning in a circle
public class SingleMovement : MonoBehaviour
{
    //Variables
    public Transform target;
    public float speed = 5f;
    public float turnSpeed = 1f;
    public float maxVelocity = 7f;
    private Rigidbody2D rb;

    void Start()
    {
        //Assigns gameObject's Rigidbody to rb variale
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    { 
        //Calls Thrust and Rotate methods
        Thrust(speed);
        Rotate(transform, -turnSpeed);
    }

    //Add velocity to rigidbody to move ship
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

    //Rotates ship
    private void Rotate(Transform transform, float amount)
    {
        transform.Rotate(0, 0, amount);
    }
}
