using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stopwatch : MonoBehaviour
{
    [HideInInspector]
    public float currentTime = 0f;
    public TextMeshProUGUI text;
    private float minutes;
    private float seconds;
    public bool isRunning = true;

    void Update()
    {
        if(isRunning) currentTime += 1 * Time.deltaTime;

        if (currentTime < 60) text.text = "00." + currentTime.ToString("f2");

        if (currentTime < 10) text.text = "00.0" + currentTime.ToString("f2");

        if (currentTime >= 60)
        {
            minutes = Mathf.Floor(currentTime / 60);
            seconds = currentTime % 60;
            if(seconds > 10) text.text = "0" + minutes.ToString("f0") + "." + seconds.ToString("f2");

            if (seconds < 10) text.text = "0" + minutes.ToString("f0") + ".0" + seconds.ToString("f2");
        }

        if(currentTime > 600)
        {
            minutes = Mathf.Floor(currentTime / 60);
            seconds = currentTime % 60;
            if (seconds > 10) text.text = "0" + minutes.ToString("f0") + "." + seconds.ToString("f2");

            if (seconds < 10) text.text = "0" + minutes.ToString("f0") + ".0" + seconds.ToString("f2");
        }
    }
}
