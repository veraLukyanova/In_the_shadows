using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    int levelUnlock;
    public Button[] buttons;

    // Start is called before the first frame update
    void Start()
   { 
        levelUnlock = PlayerPrefs.GetInt("levels", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < levelUnlock; i++)
        {
            buttons[i].interactable = true;
        }
    }
    public void Reset()
    {
        for (int i = 1; i < levelUnlock; i++)
        {
            buttons[i].interactable = false;
        }
    }

    public void Level1(int Index)
    {
        SceneManager.LoadScene(Index);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene (0);
    }
}