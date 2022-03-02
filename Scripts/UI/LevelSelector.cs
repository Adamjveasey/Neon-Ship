using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Uses the saved data from the PlayerPrefs to properly load the leves according to player progession
public class LevelSelector : MonoBehaviour
{
    // Array of all the level buttons in UI
    public Button[] levelButtons;

    void Start()
    {
        // Gets the max level reached and if there is none auto assigns 1
        int levelReached = PlayerPrefs.GetInt("LevelReached", 1);

        // Goes through all the buttons in the array
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelNumber = i + 1;

            // Checks if the level has not been reached and deactivates the corresponding button
            if (levelNumber > levelReached)
            {
                levelButtons[i].gameObject.SetActive(false);
            }

            // Checks the score acheived in each level and diplays the according number of stars next to each level
            if (PlayerPrefs.GetInt("Level " + levelNumber.ToString() + " Score") == 3)
            {
                for (int j = 1; j < 7; j++)
                { 
                    if (j % 2 == 1) levelButtons[i].transform.GetChild(j).gameObject.SetActive(false);
                    if (j % 2 == 0) levelButtons[i].transform.GetChild(j).gameObject.SetActive(true);
                }
            }

            if (PlayerPrefs.GetInt("Level " + levelNumber.ToString() + " Score") == 2)
            {
                for (int j = 3; j < 7; j++)
                {
                    if (j % 2 == 1) levelButtons[i].transform.GetChild(j).gameObject.SetActive(false);
                    if (j % 2 == 0) levelButtons[i].transform.GetChild(j).gameObject.SetActive(true);
                }
            }

            if (PlayerPrefs.GetInt("Level " + levelNumber.ToString() + " Score") == 3)
            {
                for (int j = 5; j < 7; j++)
                {
                    if (j % 2 == 1) levelButtons[i].transform.GetChild(j).gameObject.SetActive(false);
                    if (j % 2 == 0) levelButtons[i].transform.GetChild(j).gameObject.SetActive(true);
                }
            }
        }
    }
}
