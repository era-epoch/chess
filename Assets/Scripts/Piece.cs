using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{


    
    private void OnMouseOver()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }

    private void OnMouseExit()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

}
