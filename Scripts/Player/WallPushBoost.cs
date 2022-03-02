using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// Makes it so when the thruster touches a wall  it boosts player speed
public class WallPushBoost : MonoBehaviour
{
    // Variables
    public Color boostColor;
    public Color normalColor;
    public SpriteRenderer spriteRenderer;
    public GameObject ship;
    public PlayerMovement playerMovementScript;
    public ParticleSystem boostBurst;
    public  float boostMultiplier;
    private float shipSpeed;
    private float rateOverDistance;

    void Start()
    {
        // Gets player speed variable from gameObject added in inspector
        shipSpeed = ship.GetComponent<PlayerMovement>().speed;

        normalColor = spriteRenderer.color;
        rateOverDistance = ship.GetComponent<ParticleSystem>().emission.rateOverDistanceMultiplier;
    }

    // Plays sound effect when boosing
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        { 
                gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            // Calls Thrust method from Player Movement and adds a multiplier to boost speed while in contact with walls
            playerMovementScript.Thrust(shipSpeed * boostMultiplier);

            // Changes Jet colour and size when boosted
            spriteRenderer.color = boostColor;

            transform.localScale = new Vector3(0.4f, 0.5f, 0.4f);
            transform.localPosition = new Vector3(0f, -0.95f, 0f);

            // Increase in rate of particle effects when boosted 
            rateOverDistance = 5;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            // Changes Jet colour and size back to normal when out of contact with a wall
            spriteRenderer.color = normalColor;

            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            transform.localPosition = new Vector3(0f, -0.9f, 0f);

            rateOverDistance = 1;

            // Plays burst particle effect to give effect of pushing off the wall
            boostBurst.Play();

            // Stops sound effec when out of boost
            gameObject.GetComponent<AudioSource>().Stop();
        }
    }
}
