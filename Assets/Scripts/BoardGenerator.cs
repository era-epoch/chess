using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{

    public Board board;
    
    public GameObject whiteTilePrefab;
    public GameObject blackTilePrefab;
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

    public int rows;
    public int cols;


    void Start()
    {
        CreateBoard();
        CreatePieces();
    }

    private void CreateBoard()
    {
        Debug.Log("Creating board at: " + board.transform.position);
        int counter = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Vector3 position = new Vector3(i, j);
                Vector3 adjPosition = position + board.transform.position;
                //Debug.Log(adjPosition);

                if (counter%2 == 0)
                {
                    GameObject tile = Instantiate(whiteTilePrefab, adjPosition, Quaternion.identity);
                    //Debug.Log(tile.transform.position);
                    board.boardTiles[i, j] = tile;
                }
                else
                {
                    GameObject tile = Instantiate(blackTilePrefab, adjPosition, Quaternion.identity);
                    //Debug.Log(tile.transform.position);
                    board.boardTiles[i, j] = tile;
                }
                counter += 1;
            }
            counter += 1;
        }
    }

    private void CreatePieces()
    {
        Vector3 pos = board.transform.position;

        GameObject wr1 = Instantiate(whiteRookPrefab, pos + new Vector3(0, 0), Quaternion.identity);
        board.boardTiles[0, 0].GetComponent<Tile>().contents = wr1;
        board.boardPieces.Add(wr1);

        GameObject wn1 = Instantiate(whiteKnightPrefab, pos + new Vector3(1, 0), Quaternion.identity);
        board.boardTiles[1, 0].GetComponent<Tile>().contents = wn1;
        board.boardPieces.Add(wn1);

        GameObject wb1 = Instantiate(whiteBishopPrefab, pos + new Vector3(2, 0), Quaternion.identity);
        board.boardTiles[2, 0].GetComponent<Tile>().contents = wb1;
        board.boardPieces.Add(wb1);

        GameObject wq1 = Instantiate(whiteQueenPrefab, pos + new Vector3(3, 0), Quaternion.identity);
        board.boardTiles[3, 0].GetComponent<Tile>().contents = wq1;
        board.boardPieces.Add(wq1);

        GameObject wk1 = Instantiate(whiteKingPrefab, pos + new Vector3(4, 0), Quaternion.identity);
        board.boardTiles[4, 0].GetComponent<Tile>().contents = wk1;
        board.boardPieces.Add(wk1);

        GameObject wb2 = Instantiate(whiteBishopPrefab, pos + new Vector3(5, 0), Quaternion.identity);
        board.boardTiles[5, 0].GetComponent<Tile>().contents = wb2;
        board.boardPieces.Add(wb2);

        GameObject wn2 = Instantiate(whiteKnightPrefab, pos + new Vector3(6, 0), Quaternion.identity);
        board.boardTiles[6, 0].GetComponent<Tile>().contents = wn2;
        board.boardPieces.Add(wn2);

        GameObject wr2 = Instantiate(whiteRookPrefab, pos + new Vector3(7, 0), Quaternion.identity);
        board.boardTiles[7, 0].GetComponent<Tile>().contents = wr2;
        board.boardPieces.Add(wr2);



        GameObject wp1 = Instantiate(whitePawnPrefab, pos + new Vector3(0, 1), Quaternion.identity);
        board.boardTiles[0, 1].GetComponent<Tile>().contents = wp1;
        board.boardPieces.Add(wp1);

        GameObject wp2 = Instantiate(whitePawnPrefab, pos + new Vector3(1, 1), Quaternion.identity);
        board.boardTiles[1, 1].GetComponent<Tile>().contents = wp2;
        board.boardPieces.Add(wp2);

        GameObject wp3 = Instantiate(whitePawnPrefab, pos + new Vector3(2, 1), Quaternion.identity);
        board.boardTiles[2, 1].GetComponent<Tile>().contents = wp3;
        board.boardPieces.Add(wp3);

        GameObject wp4 = Instantiate(whitePawnPrefab, pos + new Vector3(3, 1), Quaternion.identity);
        board.boardTiles[3, 1].GetComponent<Tile>().contents = wp4;
        board.boardPieces.Add(wp4);

        GameObject wp5 = Instantiate(whitePawnPrefab, pos + new Vector3(4, 1), Quaternion.identity);
        board.boardTiles[4, 1].GetComponent<Tile>().contents = wp5;
        board.boardPieces.Add(wp5);

        GameObject wp6 = Instantiate(whitePawnPrefab, pos + new Vector3(5, 1), Quaternion.identity);
        board.boardTiles[5, 1].GetComponent<Tile>().contents = wp6;
        board.boardPieces.Add(wp6);

        GameObject wp7 = Instantiate(whitePawnPrefab, pos + new Vector3(6, 1), Quaternion.identity);
        board.boardTiles[6, 1].GetComponent<Tile>().contents = wp7;
        board.boardPieces.Add(wp7);

        GameObject wp8 = Instantiate(whitePawnPrefab, pos + new Vector3(7, 1), Quaternion.identity);
        board.boardTiles[7, 1].GetComponent<Tile>().contents = wp8;
        board.boardPieces.Add(wp8);


        GameObject bp1 = Instantiate(blackPawnPrefab, pos + new Vector3(0, 6), Quaternion.identity);
        board.boardTiles[0, 6].GetComponent<Tile>().contents = bp1;
        board.boardPieces.Add(bp1);

        GameObject bp2 = Instantiate(blackPawnPrefab, pos + new Vector3(1, 6), Quaternion.identity);
        board.boardTiles[1, 6].GetComponent<Tile>().contents = bp2;
        board.boardPieces.Add(bp2);

        GameObject bp3 = Instantiate(blackPawnPrefab, pos + new Vector3(2, 6), Quaternion.identity);
        board.boardTiles[2, 6].GetComponent<Tile>().contents = bp3;
        board.boardPieces.Add(bp3);

        GameObject bp4 = Instantiate(blackPawnPrefab, pos + new Vector3(3, 6), Quaternion.identity);
        board.boardTiles[3, 6].GetComponent<Tile>().contents = bp4;
        board.boardPieces.Add(bp4);

        GameObject bp5 = Instantiate(blackPawnPrefab, pos + new Vector3(4, 6), Quaternion.identity);
        board.boardTiles[4, 6].GetComponent<Tile>().contents = bp5;
        board.boardPieces.Add(bp5);

        GameObject bp6 = Instantiate(blackPawnPrefab, pos + new Vector3(5, 6), Quaternion.identity);
        board.boardTiles[5, 6].GetComponent<Tile>().contents = bp6;
        board.boardPieces.Add(bp6);

        GameObject bp7 = Instantiate(blackPawnPrefab, pos + new Vector3(6, 6), Quaternion.identity);
        board.boardTiles[6, 6].GetComponent<Tile>().contents = bp7;
        board.boardPieces.Add(bp7);

        GameObject bp8 = Instantiate(blackPawnPrefab, pos + new Vector3(7, 6), Quaternion.identity);
        board.boardTiles[7, 6].GetComponent<Tile>().contents = bp8;
        board.boardPieces.Add(bp8);


        GameObject br1 = Instantiate(blackRookPrefab, pos + new Vector3(0, 7), Quaternion.identity);
        board.boardTiles[0, 7].GetComponent<Tile>().contents = br1;
        board.boardPieces.Add(br1);

        GameObject bn1 = Instantiate(blackKnightPrefab, pos + new Vector3(1, 7), Quaternion.identity);
        board.boardTiles[1, 7].GetComponent<Tile>().contents = bn1;
        board.boardPieces.Add(bn1);

        GameObject bb1 = Instantiate(blackBishopPrefab, pos + new Vector3(2, 7), Quaternion.identity);
        board.boardTiles[2, 7].GetComponent<Tile>().contents = bb1;
        board.boardPieces.Add(bb1);

        GameObject bq1 = Instantiate(blackQueenPrefab, pos + new Vector3(3, 7), Quaternion.identity);
        board.boardTiles[3, 7].GetComponent<Tile>().contents = bq1;
        board.boardPieces.Add(bq1);

        GameObject bk1 = Instantiate(blackKingPrefab, pos + new Vector3(4, 7), Quaternion.identity);
        board.boardTiles[4, 7].GetComponent<Tile>().contents = bk1;
        board.boardPieces.Add(bk1);

        GameObject bb2 = Instantiate(blackBishopPrefab, pos + new Vector3(5, 7), Quaternion.identity);
        board.boardTiles[5, 7].GetComponent<Tile>().contents = bb2;
        board.boardPieces.Add(bb2);

        GameObject bn2 = Instantiate(blackKnightPrefab, pos + new Vector3(6, 7), Quaternion.identity);
        board.boardTiles[6, 7].GetComponent<Tile>().contents = bn2;
        board.boardPieces.Add(bn2);

        GameObject br2 = Instantiate(blackRookPrefab, pos + new Vector3(7, 7), Quaternion.identity);
        board.boardTiles[7, 7].GetComponent<Tile>().contents = br2;
        board.boardPieces.Add(br2);

    }
}
