using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelController : MonoBehaviour
{
    public Button Level1;
    public Button Level2;
    public Button Level3;
    public Button Level4;
    int levelComplete;

    void Start()
    {
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        Level2.interactable = false;
        Level3.interactable = false;
        Level4.interactable = false;

        switch (levelComplete)
        {
            case 1:
                Level2.interactable = true;
                break;
            case 2:
                Level2.interactable = true;
                Level3.interactable = true;
                break;
            case 3:
                Level2.interactable = true;
                Level3.interactable = true;
                Level4.interactable = true;
                break;
        }
    }

    public void Level(int Index)
    {
        SceneManager.LoadScene(Index);
    }

    public void BackToMenu() 
    {
        SceneManager.LoadScene (0);
    }
    public void Reset()
    {
        Level2.interactable = false;
        Level3.interactable = false;
        Level4.interactable = false;
        PlayerPrefs.DeleteAll();
    }
}