using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestController : MonoBehaviour
{
    public bool isOpen;
    public Animator animator;
    public GameObject obj;
    public GameObject cardImage;
    public Sprite sprite; 
    public void OpenChest()
    {
        if (!isOpen)
        {
            Image imj = cardImage.GetComponent<Image>();
            imj.sprite = sprite;
      
            isOpen = true;
            Debug.Log("Chest  has Oppened");
            animator.SetBool("IsOpen", true);
            obj.SetActive(true);
        }

    }
}
