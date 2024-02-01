using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{

    public Canvas canvas;
    public Canvas slsh;
    public void StartTheGame()
    {
        canvas.enabled = false;
        slsh.enabled = true;
        
    }
    public void QuitTheGame()
    {
        Application.Quit();
    }
}
