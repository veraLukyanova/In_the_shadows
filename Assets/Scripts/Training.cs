using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Training : MonoBehaviour
{
    public Button[] buttons;

    public void Level1(int Index)
    {
        SceneManager.LoadScene(Index);
    }

    public void BackMenu2() 
    {
        SceneManager.LoadScene (0);
    }
}
