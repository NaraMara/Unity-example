using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Path : MonoBehaviour
{

    public Vector2 startPosition, endPosition;

    void Reset()
    {
        startPosition = Vector3.left;
        endPosition = Vector3.right;
    }
}
