using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Changes player gravitational modifier when in the zone
public class GravityZone : MonoBehaviour
{
    public float zoneGravity = 0.7f;
    public float worldGravity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.attachedRigidbody.gravityScale = zoneGravity;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") collision.attachedRigidbody.gravityScale = worldGravity;
    }
}
