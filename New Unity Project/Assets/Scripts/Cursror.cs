using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursror : MonoBehaviour
{

    public Texture2D CursorSprite;

    void Start()
    {
        Cursor.SetCursor(CursorSprite, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
