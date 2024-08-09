using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void Loadscene()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex + 1);
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene("Main_Menu");
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

