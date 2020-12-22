using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject[,] boardTiles;
    public List<GameObject> boardPieces;
    private bool isTileSelected;
    private GameObject selectedTile;


    private void Awake()
    {
        boardTiles = new GameObject[8, 8];
        boardPieces = new List<GameObject>();
        isTileSelected = false;
    }

    private void Update()
    {
        CheckLeftClick();
    }

    public GameObject GetTileAtMouse()
    {
        foreach (GameObject tile in boardTiles)
        {
            if (tile.GetComponent<Tile>().hovering)
            {
                Debug.Log(tile);
                return tile;
            }
        }
        Debug.Log("No tile found");
        return null;
    }

    private void CheckLeftClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject tile = GetTileAtMouse();
            if (tile != null)
            {
                if (isTileSelected)
                {
                    Debug.Log(tile.GetComponent<Tile>().contents);

                    tile.GetComponent<Tile>().contents = selectedTile.GetComponent<Tile>().contents;
                    selectedTile.GetComponent<Tile>().contents = new GameObject();
                    selectedTile.GetComponent<Tile>().selected = false;
                    isTileSelected = false;
                    selectedTile = null;

                }
                else
                {
                    isTileSelected = true;
                    selectedTile = tile;
                    tile.GetComponent<Tile>().selected = true;
                }
            }
        }
    }

}
