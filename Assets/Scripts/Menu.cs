using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Bumblebee_Game");
    }
    
    public void Quit_Game()
    {
        Application.Quit();
    }
    
    public void ToTitlescreen()
    {
        SceneManager.LoadScene("Titlescreen");

    }

    public void Controls()
    {
        SceneManager.LoadScene("Manual");
 
    }
}
