using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public bool hovering;
    public bool selected = false;
    private Piece contents;



    public Vector3 relativepos(Board board)
    {
        return transform.position - board.transform.position;
    }
    
    
    public void SetContents(Piece obj)
    {
        this.contents = obj;
    }

    public Piece GetContents()
    {
        return this.contents;
    }


    private void Update()
    {
        UpdateContentPos();

        if (selected)
        {
            Highlight();
        }

    }
    
    private void UpdateContentPos()
    {
        contents.transform.position = transform.position;
    }

    public void Capture(Board board)
    {
        if (contents != null)
        {
            Destroy(contents.gameObject);
            
        }
        Empty(board);
    }


    public void Empty(Board board)
    {
        GameObject empty = Instantiate(board.emptyPiecePrefab, transform.position, Quaternion.identity);
        contents = empty.GetComponent<Piece>();
        board.pieces.Add(empty.GetComponent<Piece>());
    }

    public void DeHighlight()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    public void Highlight()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }

    private void OnMouseOver()
    {

        Highlight();
        hovering = true;
    }

    private void OnMouseExit()
    {

        DeHighlight();
        hovering = false;
    }

}
