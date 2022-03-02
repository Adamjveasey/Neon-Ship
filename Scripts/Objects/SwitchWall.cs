using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Swiches active wall when player passes a certain point in the map
public class SwitchWall : MonoBehaviour
{
    // Gets both wall objects in inspector
    public GameObject wall_1;
    public GameObject wall_2;

    //Checks for trigger collision
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Checks if the collided object is the player ship
        if (collision.tag == "Player")
        {
            // Activates and Deactivates walls accordingly to wich is currently active
            if (wall_1.activeSelf)
            {
                wall_1.SetActive(false);
                wall_2.SetActive(true);
            }

            else if (wall_2.activeSelf)
            {
                wall_1.SetActive(true);
                wall_2.SetActive(false);
            }
        }
    }
}
