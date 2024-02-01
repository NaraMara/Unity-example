using System.Collections;
 
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayer : MonoBehaviour
{
    public Canvas canvas;
    private VideoPlayer vp;


    public void PlayVideo()
    {
        canvas.enabled = false;
        GetComponent<VideoPlayer>().enabled = true;
        GetComponent<VideoPlayer>().PlayVideo();


    }
}
