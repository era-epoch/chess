using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{

    public Board board;

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

                if (counter%2 == 0)
                {
                    GameObject tile = Instantiate(board.whiteTilePrefab, adjPosition, Quaternion.identity);
                    board.tiles[i, j] = tile.GetComponent<Tile>();
                }
                else
                {
                    GameObject tile = Instantiate(board.blackTilePrefab, adjPosition, Quaternion.identity);
                    board.tiles[i, j] = tile.GetComponent<Tile>();
                }
                counter += 1;
            }
            counter += 1;
        }
    }

    private void CreatePieces()
    {
        Vector3 pos = board.transform.position;

        GameObject wr1 = Instantiate(board.whiteRookPrefab, pos + new Vector3(0, 0), Quaternion.identity);
        board.tiles[0, 0].SetContents(wr1.GetComponent<Piece>());
        board.pieces.Add(wr1.GetComponent<Piece>());

        GameObject wn1 = Instantiate(board.whiteKnightPrefab, pos + new Vector3(1, 0), Quaternion.identity);
        board.tiles[1, 0].SetContents(wn1.GetComponent<Piece>());
        board.pieces.Add(wn1.GetComponent<Piece>());

        GameObject wb1 = Instantiate(board.whiteBishopPrefab, pos + new Vector3(2, 0), Quaternion.identity);
        board.tiles[2, 0].SetContents(wb1.GetComponent<Piece>());
        board.pieces.Add(wb1.GetComponent<Piece>());

        GameObject wq1 = Instantiate(board.whiteQueenPrefab, pos + new Vector3(3, 0), Quaternion.identity);
        board.tiles[3, 0].SetContents(wq1.GetComponent<Piece>());
        board.pieces.Add(wq1.GetComponent<Piece>());

        GameObject wk1 = Instantiate(board.whiteKingPrefab, pos + new Vector3(4, 0), Quaternion.identity);
        board.tiles[4, 0].SetContents(wk1.GetComponent<Piece>());
        board.pieces.Add(wk1.GetComponent<Piece>());

        GameObject wb2 = Instantiate(board.whiteBishopPrefab, pos + new Vector3(5, 0), Quaternion.identity);
        board.tiles[5, 0].SetContents(wb2.GetComponent<Piece>());
        board.pieces.Add(wb2.GetComponent<Piece>());

        GameObject wn2 = Instantiate(board.whiteKnightPrefab, pos + new Vector3(6, 0), Quaternion.identity);
        board.tiles[6, 0].SetContents(wn2.GetComponent<Piece>());
        board.pieces.Add(wn2.GetComponent<Piece>());

        GameObject wr2 = Instantiate(board.whiteRookPrefab, pos + new Vector3(7, 0), Quaternion.identity);
        board.tiles[7, 0].SetContents(wr2.GetComponent<Piece>());
        board.pieces.Add(wr2.GetComponent<Piece>());

        int i = 0;
        while (i < cols)
        {
            GameObject pawn = Instantiate(board.whitePawnPrefab, pos + new Vector3(i, 1), Quaternion.identity);
            board.tiles[i, 1].SetContents(pawn.GetComponent<Piece>());
            board.pieces.Add(pawn.GetComponent<Piece>());
            i += 1;
        }

        i = 0;
        while (i < cols)
        {
            GameObject empty = Instantiate(board.emptyPiecePrefab, pos + new Vector3(i, 2), Quaternion.identity);
            board.tiles[i, 2].SetContents(empty.GetComponent<Piece>());
            board.pieces.Add(empty.GetComponent<Piece>());
            empty = Instantiate(board.emptyPiecePrefab, pos + new Vector3(i, 3), Quaternion.identity);
            board.tiles[i, 3].SetContents(empty.GetComponent<Piece>());
            board.pieces.Add(empty.GetComponent<Piece>());
            empty = Instantiate(board.emptyPiecePrefab, pos + new Vector3(i, 4), Quaternion.identity);
            board.tiles[i, 4].SetContents(empty.GetComponent<Piece>());
            board.pieces.Add(empty.GetComponent<Piece>());
            empty = Instantiate(board.emptyPiecePrefab, pos + new Vector3(i, 5), Quaternion.identity);
            board.tiles[i, 5].SetContents(empty.GetComponent<Piece>());
            board.pieces.Add(empty.GetComponent<Piece>());
            i += 1;
        }


        i = 0;
        while (i < cols)
        {
            GameObject pawn = Instantiate(board.blackPawnPrefab, pos + new Vector3(i, 6), Quaternion.identity);
            board.tiles[i, 6].SetContents(pawn.GetComponent<Piece>());
            board.pieces.Add(pawn.GetComponent<Piece>());
            i += 1;
        }

        GameObject br1 = Instantiate(board.blackRookPrefab, pos + new Vector3(0, 7), Quaternion.identity);
        board.tiles[0, 7].SetContents(br1.GetComponent<Piece>());
        board.pieces.Add(br1.GetComponent<Piece>());

        GameObject bn1 = Instantiate(board.blackKnightPrefab, pos + new Vector3(1, 7), Quaternion.identity);
        board.tiles[1, 7].SetContents(bn1.GetComponent<Piece>());
        board.pieces.Add(bn1.GetComponent<Piece>());

        GameObject bb1 = Instantiate(board.blackBishopPrefab, pos + new Vector3(2, 7), Quaternion.identity);
        board.tiles[2, 7].SetContents(bb1.GetComponent<Piece>());
        board.pieces.Add(bb1.GetComponent<Piece>());

        GameObject bk1 = Instantiate(board.blackKingPrefab, pos + new Vector3(3, 7), Quaternion.identity);
        board.tiles[3, 7].SetContents(bk1.GetComponent<Piece>());
        board.pieces.Add(bk1.GetComponent<Piece>());

        GameObject bq1 = Instantiate(board.blackQueenPrefab, pos + new Vector3(4, 7), Quaternion.identity);
        board.tiles[4, 7].SetContents(bq1.GetComponent<Piece>());
        board.pieces.Add(bq1.GetComponent<Piece>());

        GameObject bb2 = Instantiate(board.blackBishopPrefab, pos + new Vector3(5, 7), Quaternion.identity);
        board.tiles[5, 7].SetContents(bb2.GetComponent<Piece>());
        board.pieces.Add(bb2.GetComponent<Piece>());

        GameObject bn2 = Instantiate(board.blackKnightPrefab, pos + new Vector3(6, 7), Quaternion.identity);
        board.tiles[6, 7].SetContents(bn2.GetComponent<Piece>());
        board.pieces.Add(bn2.GetComponent<Piece>());

        GameObject br2 = Instantiate(board.blackRookPrefab, pos + new Vector3(7, 7), Quaternion.identity);
        board.tiles[7, 7].SetContents(br2.GetComponent<Piece>());
        board.pieces.Add(br2.GetComponent<Piece>());
    }
}
