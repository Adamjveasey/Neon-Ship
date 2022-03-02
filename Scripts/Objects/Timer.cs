using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Sets a countdown timer in objecive UI
public class Timer : MonoBehaviour
{
    // Variables
    private float currentTime = 0f;
    public float staringTime = 40f; // given in seconds
    public TextMeshProUGUI timerText;
    public GameObject objectiveUI;
    public GameObject levelFailedUI;
    public GameObject ship;
    public GameObject shipJet;
    public bool isExit = false;
    public bool isLaps = true;
    private float minutes;
    private float seconds;

    void Start()
    {
        // Sets current time to given start time
        currentTime = staringTime;
        if (isLaps)
        {
            if (currentTime < 60) timerText.text = "Objective: Do    laps(s) in 00." + currentTime.ToString("f2");

            if (currentTime < 10) timerText.text = "Objective: Do    laps(s) in 00.0" + currentTime.ToString("f2");

            if (currentTime >= 60)
            {
                minutes = Mathf.Floor(currentTime / 60);
                seconds = currentTime % 60;
                if (seconds > 10) timerText.text = "Objective: Do    laps(s) in 0" + minutes.ToString("f0") + "." + seconds.ToString("f2");

                if (seconds < 10) timerText.text = "Objective: Do    laps(s) in 0" + minutes.ToString("f0") + ".0" + seconds.ToString("f2");
            }
        }

        if (isExit)
        {
            if (currentTime < 60) timerText.text = "Objective: Reach the Exit in 00." + currentTime.ToString("f2");

            if (currentTime < 10) timerText.text = "Objective: Reach the Exit in 00.0" + currentTime.ToString("f2");

            if (currentTime >= 60)
            {
                minutes = Mathf.Floor(currentTime / 60);
                seconds = currentTime % 60;
                if (seconds > 10) timerText.text = "Objective: Reach the Exit in 0" + minutes.ToString("f0") + "." + seconds.ToString("f2");

                if (seconds < 10) timerText.text = "Objective: Reach the Exit in 0" + minutes.ToString("f0") + ".0" + seconds.ToString("f2");
            }
        }
    }

    void Update()
    {
        // Decreases currenTime every in-game second
        currentTime -= 1 * Time.deltaTime;

        if (isLaps)
        {
            if (currentTime < 60) timerText.text = "Objective: Do    laps(s) in 00." + currentTime.ToString("f2");

            if (currentTime < 10) timerText.text = "Objective: Do    lap(s) in 00.0" + currentTime.ToString("f2");

            if (currentTime >= 60)
            {
                minutes = Mathf.Floor(currentTime / 60);
                seconds = currentTime % 60;
                if (seconds > 10) timerText.text = "Objective: Do    lap(s) in 0" + minutes.ToString("f0") + "." + seconds.ToString("f2");

                if (seconds < 10) timerText.text = "Objective: Do    lap(s) in 0" + minutes.ToString("f0") + ".0" + seconds.ToString("f2");
            }
        }

        if (isExit)
        {
            if (currentTime < 60) timerText.text = "Objective: Reach the Exit in 00." + currentTime.ToString("f2");

            if (currentTime < 10) timerText.text = "Objective: Reach the Exit in 00.0" + currentTime.ToString("f2");

            if (currentTime >= 60)
            {
                minutes = Mathf.Floor(currentTime / 60);
                seconds = currentTime % 60;
                if (seconds > 10) timerText.text = "Objective: Reach the Exit in 0" + minutes.ToString("f0") + "." + seconds.ToString("f2");

                if (seconds < 10) timerText.text = "Objective: Reach the Exit in 0" + minutes.ToString("f0") + ".0" + seconds.ToString("f2");
            }
        }

        // Checks lose condition of time running out
        if (currentTime <= 0 && objectiveUI.activeSelf)
        {
            // Stops player movement and switches active UI elements accordingly
            objectiveUI.SetActive(false);
            levelFailedUI.SetActive(true);
            ship.GetComponent<PlayerMovement>().startDelay = 51f;
            shipJet.SetActive(false);
        }
    }
}
