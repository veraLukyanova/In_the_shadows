using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public static playerController instance = null;
    int sceneIndex;
    int levelComplete;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
    }

    public void isEndGame()
    {
        if(sceneIndex == 4)
        {
            Invoke(/*levelController*/"Menu", 1f);
        }
        else
        {
            if(levelComplete < sceneIndex)
                PlayerPrefs.SetInt("LevelComplete", sceneIndex);
            Invoke("WIN", 1f);
        }
    }

    void WIN()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }
    void levelController()
    {
        SceneManager.LoadScene("Menu");
    }

    public void win_back_levels() 
    {
        playerController.instance.isEndGame();
        SceneManager.LoadScene (5);
    }
}
