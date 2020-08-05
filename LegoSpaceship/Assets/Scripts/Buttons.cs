using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Buttons : MonoBehaviour
{
    public GameObject WinPopup;
    
    public void LaunchGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        
        

    }

    public void QuitGame()
    {
        Application.Quit();
        

    }
}
