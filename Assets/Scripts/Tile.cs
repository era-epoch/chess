using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public bool hovering;
    public bool selected = false;
    public GameObject contents;

    private void Start()
    {
        Empty();
        contents = new GameObject();
    }

    private void Update()
    {
        UpdateContentPos();
    }
    
    private void UpdateContentPos()
    {
        contents.transform.position = this.transform.position;
    }


    public void Empty()
    {
        contents = null;
    }

    private void OnMouseOver()
    {
        
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
        hovering = true;
    }

    private void OnMouseExit()
    {

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        hovering = false;
    }

}
