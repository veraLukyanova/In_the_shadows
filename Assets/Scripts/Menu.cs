using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngineUI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Training(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
