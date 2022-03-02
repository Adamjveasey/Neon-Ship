using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Ends level when crossed and objecives are complete
public class FinishLine : MonoBehaviour
{
    // Variables
    public float lapsNeeded;
    public TextMeshProUGUI lapText;
    public GameObject levelCompleteUI;
    public GameObject objectiveUI;
    public GameObject ship;
    public GameObject shipJet;
    public Stopwatch stopwatch;
    public float starScore3;
    public float starScore2;
    public int levelNumber;

    private float lapsToGo;
    private float lapsDone;
    private int highScore;
    private int levelReached;

    void Start()
    {
        // Sets amount of laps shown in UI to number of laps needed
        lapsToGo = lapsNeeded;
        lapText.text = lapsToGo.ToString();

        highScore = PlayerPrefs.GetInt("Level " + levelNumber.ToString() + " Score", 0);
        levelReached = PlayerPrefs.GetInt("LevelReached", 0);
    }

    void Update()
    {
        // Checks win condition
        if (lapsDone == lapsNeeded && objectiveUI.activeSelf)
        {
            // Ajusts delay variable in ship to stop movement and swiches active UI elements
            ship.GetComponent<PlayerMovement>().startDelay = 51f;
            shipJet.SetActive(false);
            levelCompleteUI.SetActive(true);
            objectiveUI.SetActive(false);
            
            // Plays confetti particle effect
            gameObject.GetComponentInChildren<ParticleSystem>().Play();

            // Stops watch
            stopwatch.isRunning = false;

            // Checks and saves score
            float time = stopwatch.currentTime;
            if (time <= starScore3) PlayerPrefs.SetInt("Level " + levelNumber.ToString() + " Score", 3);

            if (highScore < 2)
            {
                if (time > starScore3 && time < starScore2) PlayerPrefs.SetInt("Level " + levelNumber + " Score", 2);

                if (highScore < 1)
                {
                    if (time > starScore2) PlayerPrefs.SetInt("Level " + levelNumber.ToString() + " Score", 1);
                }
            }

            // Saves the max level reached
            if(levelNumber >= levelReached) PlayerPrefs.SetInt("LevelReached", levelNumber + 1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Checks trigger collision with player and changes laps done and UI display accordingly
        if (collision.tag == "Player")
        {
            lapsDone++;
            lapsToGo--;
            lapText.text = lapsToGo.ToString();
        }
    }
}
