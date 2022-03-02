using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Key object script to make it interactable
public class Key : MonoBehaviour
{
    // Gets KeyCopy object in inspector
    public GameObject KeyCopy;

    // Checks for collision with player ship
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            // Deactivates collectable key and activates KeyCopy
            gameObject.SetActive(false);
            KeyCopy.SetActive(true);
            // KeyCopy is attached to player ship with a Distance Joint
        }
    }
}
