using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class slideShow : MonoBehaviour
{
    private float number = 2;
    public Image placeHolder;
    public Sprite im1;
    public Sprite im2;
    public Sprite im3;
    public Sprite im4;



    public void NextPic()
    {

        if (number == 2) { placeHolder.sprite = im2; number++; }

        if (number == 3) { placeHolder.sprite = im3; number++; }

        if (number == 4) { placeHolder.sprite = im4; number++; }

        if (number ==5) NextStage();
        
    }
    public void NextStage()
    {
        SceneManager.LoadScene(1);

    }
}
