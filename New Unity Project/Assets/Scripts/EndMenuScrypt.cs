﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuScrypt : MonoBehaviour
{

    public void QuitTheGame()
    {
        Application.Quit();
    }
    public void restartGame(){
        SceneManager.LoadScene(0);
    }
}
