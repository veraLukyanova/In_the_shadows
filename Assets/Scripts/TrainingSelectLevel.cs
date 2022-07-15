using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrainingSelectLevel : MonoBehaviour
{
    int levelUnlocks;
    public Button[] buttons;

    // Start is called before the first frame update
    void Start()
   { 
        levelUnlocks = PlayerPrefs.GetInt("LevelsTraining", 1);
        
        for (int i = 0; i < levelUnlocks; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void Level11(int Index)
    {
        SceneManager.LoadScene(Index);
    }

    public void BackMenu()
    {
        SceneManager.LoadScene (0);
    }
}

