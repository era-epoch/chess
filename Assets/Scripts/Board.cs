using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private bool isTileSelected;
    private Tile selectedTile;
    public int turnNum;
    public Tile[,] tiles;
    public List<Piece> pieces;
    //public List<Piece> whitePieces;
    //public List<Piece> blackPieces;
    public int rows;
    public int cols;

    public GameObject moveTileHighlight;
    private List<GameObject> tileHighlights;

    public GameObject whiteTilePrefab;
    public GameObject blackTilePrefab;

    public GameObject emptyPiecePrefab;

    public GameObject blackPawnPrefab;
    public GameObject whitePawnPrefab;
    public GameObject blackRookPrefab;
    public GameObject whiteRookPrefab;
    public GameObject blackKnightPrefab;
    public GameObject whiteKnightPrefab;
    public GameObject blackBishopPrefab;
    public GameObject whiteBishopPrefab;
    public GameObject blackKingPrefab;
    public GameObject whiteKingPrefab;
    public GameObject blackQueenPrefab;
    public GameObject whiteQueenPrefab;


    private void Awake()
    {
        tiles = new Tile[8, 8];
        pieces = new List<Piece>();
        //whitePieces = new List<Piece>();
        //blackPieces = new List<Piece>();
        tileHighlights = new List<GameObject>();
        isTileSelected = false;
        turnNum = 0;
    }

    private void Update()
    {
        LeftClickBehaviour();
        if (isTileSelected)
        {
            HighlightPossibleMoves();
        }

    }

    private void LeftClickBehaviour()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Tile tile = GetTileAtMouse();

            if (tile != null)
            {
                if (isTileSelected)
                {
                    if (tile != selectedTile)
                    {
                        if (tile.GetContents().owner == selectedTile.GetContents().owner)
                        {
                            Deselect();
                            SelectTile(tile);
                        }
                        
                        else if (selectedTile.GetContents().GetValidMoves(this).Contains(tile.transform.position - transform.position))
                        {
                            MovePiece(selectedTile, tile);
                        }
                        else
                        {
                            Debug.Log("Cannot move here");
                        }
                    }
                    else
                    {
                        Deselect();
                    }
                }
                else if (tile.GetContents().GetOwner() == TurnOwner())
                {
                    SelectTile(tile);
                    Debug.Log("Selected Tile: " + tile);
                }
                else
                {
                    Debug.Log("Invalid Piece selected");
                }
            }
        }
    }

    public void MovePiece(Tile initTile, Tile tile)
    {
        MoveToTile(initTile, tile);

        // Check for castles

        if (tile.GetContents() is King)
        {
                        
            Vector3 adjPos = selectedTile.relativepos(this);

            if (tile.relativepos(this).x - adjPos.x > 1)
            {
                SwapTiles(tiles[cols - 1, (int)adjPos.y], tiles[(int)adjPos.x + 1, (int)adjPos.y]);
            }
            else if (tile.relativepos(this).x - adjPos.x < -1)
            {
                SwapTiles(tiles[0, (int)adjPos.y], tiles[(int)adjPos.x - 1, (int)adjPos.y]);
            }
        }

        Deselect();
        NextTurn();
    }

    public bool TryMoveForCheck(Piece piece, Vector3 move)
    {

        return false;

    }

    public bool InCheck(string owner)
    {
        Tile kingTile = FindKing(owner);
        return IsTileAttacked(kingTile, owner);
    }


    public Tile FindKing(string owner)
    {
        foreach(Tile tile in tiles)
        {
            Piece piece = tile.GetContents();
            if (piece.owner == owner && piece is King)
            {
                return tile;
            }
        }
        return null;
    }

    public bool IsTileAttacked(Tile tile, string owner)
    {
        foreach(Piece piece in pieces)
        {
            //Debug.Log(piece);
            if (piece.GetOwner() != owner & !(piece is Empty))
            {
                Vector3 pos = tile.relativepos(this);
                if (piece.GetAttacks(this).Contains(pos))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public int LevelOfThreat(Tile tile, string owner) {

        int threatCount = 0;
        foreach(Piece piece in pieces)
        {
            if (piece.GetOwner() != owner)
            {
                Vector3 pos = tile.relativepos(this);
                if (piece.GetValidMoves(this).Contains(pos))
                {
                    threatCount += 1;
                }
            }
        }
        return threatCount;
    }


    private void HighlightPossibleMoves()
    {
        List<Vector3> validMoves = selectedTile.GetContents().GetValidMoves(this);
        foreach (Vector3 move in validMoves)
        {
            Vector3 adjMove = move + transform.position;
            GameObject tileHighlight = Instantiate(moveTileHighlight, adjMove, Quaternion.identity);
            tileHighlights.Add(tileHighlight);
        }
    }

    private void RemoveHighlights()
    {
        foreach(GameObject tileHighlight in tileHighlights)
        {
            Destroy(tileHighlight);
        }
    }

    private void Deselect()
    {
        selectedTile.selected = false;
        selectedTile.DeHighlight();
        isTileSelected = false;
        selectedTile = null;
        RemoveHighlights();
    }

    private string TurnOwner()
    {
        if (turnNum % 2 == 0)
        {
            return "w";
        }
        else
        {
            return "b";
        }
    }

    private Tile GetTileAtMouse()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (tiles[i, j].hovering)
                {
                    Debug.Log(tiles[i, j].GetContents());

                    return tiles[i, j];
                }
            }
        }

        Debug.Log("No tile found");
        return null;
    }

    private void SelectTile(Tile tile)
    {
        isTileSelected = true;
        selectedTile = tile;
        tile.selected = true;
    }

    private void SwapTiles(Tile t1, Tile t2)
    {
        Piece p1 = t1.GetContents();
        Piece p2 = t2.GetContents();
        t2.SetContents(p1);
        if (p1 != null)
        {
            p1.hasMoved = true;
        }
        t1.SetContents(p2);
        if (p2 != null)
        {
            p2.hasMoved = true;
        }
    }

    private void MoveToTile(Tile selectedTile, Tile tile)
    {
        pieces.Remove(tile.GetContents());
        tile.Capture(this);

        tile.SetContents(selectedTile.GetContents());
        tile.GetContents().hasMoved = true;
        if (tile.GetContents() is Pawn)
        {
            // If pawn moved 2 places, give it the En Passant condition until player's next turn
            if (Mathf.Abs(tile.relativepos(this).y - selectedTile.relativepos(this).y) > 1)
            {
                tile.GetContents().SetStatus(new EnPassant(2));
            }
            // Check for en passant captures
            if (tile.GetContents().owner == "w")
            {
                if (tiles[(int)tile.relativepos(this).x, (int)tile.relativepos(this).y - 1].GetContents() != null
                && tiles[(int)tile.relativepos(this).x, (int)tile.relativepos(this).y - 1].GetContents().owner != tile.GetContents().owner
                && tiles[(int)tile.relativepos(this).x, (int)tile.relativepos(this).y - 1].GetContents().CheckCondition<EnPassant>())
                {
                    pieces.Remove(tiles[(int)tile.relativepos(this).x, (int)tile.relativepos(this).y - 1].GetContents());
                    tiles[(int)tile.relativepos(this).x, (int)tile.relativepos(this).y - 1].Capture(this);
                }
            }
            else
            {
                if (tiles[(int)tile.relativepos(this).x, (int)tile.relativepos(this).y + 1].GetContents() != null
                && tiles[(int)tile.relativepos(this).x, (int)tile.relativepos(this).y + 1].GetContents().owner != tile.GetContents().owner
                && tiles[(int)tile.relativepos(this).x, (int)tile.relativepos(this).y + 1].GetContents().CheckCondition<EnPassant>())
                {
                    pieces.Remove(tiles[(int)tile.relativepos(this).x, (int)tile.relativepos(this).y + 1].GetContents());
                    tiles[(int)tile.relativepos(this).x, (int)tile.relativepos(this).y + 1].Capture(this);
                }
            }
            // Check for Pawn promotions
            if (tile.GetContents().owner == "w" && tile.relativepos(this).y > 6)
            {
                PromotePawn(tile, "w");
            } 
            else if (tile.GetContents().owner == "b" && tile.relativepos(this).y < 1)
            {
                PromotePawn(tile, "b");
            }
        }
        selectedTile.Empty(this);
    }

    private void NextTurn()
    {
        turnNum += 1;
        foreach (Piece piece in pieces)
        {
            piece.TurnUpdate();
        }
    }

    private void PromotePawn(Tile tile, string owner)
    {
        pieces.Remove(tile.GetContents());
        tile.Capture(this);
        if (owner == "w")
        {
            tile.SetContents(Instantiate(whiteQueenPrefab, tile.relativepos(this), Quaternion.identity).GetComponent<Piece>());
        }
        else
        {
            tile.SetContents(Instantiate(blackQueenPrefab, tile.relativepos(this), Quaternion.identity).GetComponent<Piece>());
        }
    }
}
