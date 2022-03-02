using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Doubles player speed when in the zone
public class BoostZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerMovement>().speed = collision.GetComponent<PlayerMovement>().speed * 2;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerMovement>().speed = collision.GetComponent<PlayerMovement>().speed / 2;
            gameObject.GetComponent<AudioSource>().Stop();
        }
    }
}
