using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    
    override public List<Vector3> GetValidMoves(Board board)
    {
        List<Vector3> lst = new List<Vector3>(); // lst = List of available legal moves
        Transform transform = GetComponentInParent<Transform>();
        Vector3 position = transform.position - board.transform.position;
        int x = (int)position.x;
        int y = (int)position.y;

        // Pawns are unique in that they move differently depending on the colour of piece they are
        if (owner == "w")
        {
            
            if (board.tiles[x, y + 1].GetContents() is Empty)
            {
                lst.Add(position + new Vector3(0, 1));
            }
            // If the pawn hasn't moved, it can move 2 spaces
            if (!hasMoved && board.tiles[x, y + 1].GetContents() is Empty && board.tiles[x, y + 2].GetContents() is Empty)
            {
                lst.Add(position + new Vector3(0, 2));
            }

            if (x > 0) {
                // Can the piece capture to the left?
                if (board.tiles[x - 1, y + 1].GetContents() != null && board.tiles[x - 1, y + 1].GetContents().GetOwner() == "b")
                {
                    lst.Add(position + new Vector3(-1, 1));
                }
                // Check for captures en passant
                if (board.tiles[x - 1, y].GetContents() != null && board.tiles[x - 1, y].GetContents().GetOwner() == "b"
                    && board.tiles[x - 1, y].GetContents().CheckCondition<EnPassant>())
                {
                    lst.Add(position + new Vector3(-1, 1));
                }
            }

            if (x < 7)
            {
                // Can the piece capture to the right?
                if (board.tiles[x + 1, y + 1].GetContents() != null && board.tiles[x + 1, y + 1].GetContents().GetOwner() == "b")
                {
                    lst.Add(position + new Vector3(1, 1));
                }
                // Check for captures en passant
                if (board.tiles[x + 1, y].GetContents() != null && board.tiles[x + 1, y].GetContents().GetOwner() == "b"
                    && board.tiles[x + 1, y].GetContents().CheckCondition<EnPassant>())
                {
                    lst.Add(position + new Vector3(1, 1));
                }
            }



        }
        else
        {
            if (board.tiles[x, y - 1].GetContents() is Empty)
            {
                lst.Add(position + new Vector3(0, -1));
            }

            // If the pawn hasn't moved, it can move 2 spaces
            if (!hasMoved && board.tiles[x, y - 1].GetContents() is Empty && board.tiles[x, y - 2].GetContents() is Empty)
            {
                lst.Add(position + new Vector3(0, -2));
            }

            if (x > 0)
            {
                // Can the piece capture left?
                if (board.tiles[x - 1, y - 1].GetContents() != null && board.tiles[x - 1, y - 1].GetContents().GetOwner() == "w")
                {
                    lst.Add(position + new Vector3(-1, -1));
                }
                // Check for captures en passant
                if (board.tiles[x - 1, y].GetContents() != null && board.tiles[x - 1, y].GetContents().GetOwner() == "w"
                    && board.tiles[x - 1, y].GetContents().CheckCondition<EnPassant>())
                {
                    lst.Add(position + new Vector3(-1, -1));
                }

            }

            if (x < 7)
            {
                // Can the piece capture right?
                if (board.tiles[x + 1, y - 1].GetContents() != null && board.tiles[x + 1, y - 1].GetContents().GetOwner() == "w")
                {
                    lst.Add(position + new Vector3(1, -1));
                }
                // Check for captures en passant
                if (board.tiles[x + 1, y].GetContents() != null && board.tiles[x + 1, y].GetContents().GetOwner() == "w"
                    && board.tiles[x + 1, y].GetContents().CheckCondition<EnPassant>())
                {
                    lst.Add(position + new Vector3(1, -1));
                }
            }
        }
        LimitMovesInCheck(lst, board);
        return lst;
    }

    override public List<Vector3> GetAttacks(Board board)
    {
        List<Vector3> lst = new List<Vector3>(); // lst = List of available legal moves
        Transform transform = GetComponentInParent<Transform>();
        Vector3 position = transform.position - board.transform.position;
        int x = (int)position.x;
        int y = (int)position.y;

        // Pawns are unique in that they move differently depending on the colour of piece they are
        if (owner == "w")
        {
            if (x > 0)
            {
                // Can the piece capture to the left?
                lst.Add(position + new Vector3(-1, 1));
            }

            if (x < 7)
            {
                // Can the piece capture to the right?
                lst.Add(position + new Vector3(1, 1));
            }
        }
        else
        {
            if (x > 0)
            {
                // Can the piece capture left?
                lst.Add(position + new Vector3(-1, -1));
            }

            if (x < 7)
            {
                // Can the piece capture right?
                lst.Add(position + new Vector3(1, -1));
            }
        }

        return lst;
    }
}
