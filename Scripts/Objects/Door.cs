using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Door object script to mak it interactable
public class Door : MonoBehaviour
{
    // Gets KeyCopy from inspector
    public GameObject KeyCopy;

    // Checks for collision with KeyCopy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == KeyCopy)
        {
            // Deactivates both door and KeyCopy on collision
            gameObject.SetActive(false);
            KeyCopy.SetActive(false);
        }
    }
}
