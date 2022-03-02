using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Methods to be called by UI buttons
public class ButtonMethods : MonoBehaviour
{
    // Scene name passed through inspector
    public string sceneName;

    // Loads specific scene via sceneName variable
    public void LoadScene()
    {
        SceneManager.LoadScene("Scenes/" + sceneName);
    }

    // Quits game
    public void Quit()
    {
        Application.Quit();
    }

    // Resets level
    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Resets display ships position, rotation and velocity when changing pages in the menus
    public void ResetShipLeft(GameObject shipLeft)
    {
        shipLeft.transform.localPosition = new Vector3(-819f, -190f, 0f);
        shipLeft.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
        shipLeft.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
    }

    public void ResetShipRight(GameObject shipRight)
    {
        shipRight.transform.localPosition = new Vector3(819f, -190f, 0f);
        shipRight.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
        shipRight.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
    }
}
