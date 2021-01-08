using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{
    
    override public List<Vector3> GetValidMoves(Board board)
    {
        List<Vector3> lst = new List<Vector3>(); // lst = List of available legal moves
        Transform transform = GetComponentInParent<Transform>();
        Vector3 position = transform.position - board.transform.position;
        int x = (int)position.x;
        int y = (int)position.y;

        lst.Add(position + new Vector3(0, 1));
        lst.Add(position + new Vector3(1, 1));
        lst.Add(position + new Vector3(1, 0));
        lst.Add(position + new Vector3(0, -1));
        lst.Add(position + new Vector3(-1, 0));
        lst.Add(position + new Vector3(-1, 1));
        lst.Add(position + new Vector3(1, -1));
        lst.Add(position + new Vector3(-1, -1));

        List<Vector3> removalList = new List<Vector3>();
        foreach (Vector3 pos in lst)
        {
            if (pos.x < 0 || pos.x >= board.cols || pos.y < 0 || pos.y >= board.rows)
            {
                removalList.Add(pos);
            }
            else if(board.tiles[(int)pos.x,(int) pos.y].GetContents() != null &&
                board.tiles[(int)pos.x, (int)pos.y].GetContents().GetOwner() == owner) {
                removalList.Add(pos);
            }
            else if (board.IsTileAttacked(board.tiles[(int)pos.x, (int)pos.y], owner))
            {
                removalList.Add(pos);
            }
        }

        foreach (Vector3 pos in removalList)
        {
            lst.Remove(pos);
        }

        // Look for possible castles
        bool castleLeft = true;
        bool castleRight = true;

        if (!hasMoved)
        {
            if (board.tiles[0, y].GetContents() != null && !board.tiles[0, y].GetContents().hasMoved)
            {
                int i = x - 1;
                while (i > 0)
                {
                    if (!(board.tiles[i, y].GetContents() is Empty))
                    {
                        castleLeft = false;
                    }
                    if (board.IsTileAttacked(board.tiles[i, y], owner))
                    {
                        castleLeft = false;
                    }
                    i -= 1;
                }
                if (castleLeft)
                {
                    lst.Add(position + new Vector3(-2, 0));
                }
            }
            if (board.tiles[7, y].GetContents() != null && !board.tiles[7, y].GetContents().hasMoved)
            {
                int i = x + 1;
                while (i < board.cols - 1)
                {
                    if (!(board.tiles[i, y].GetContents() is Empty))
                    {
                        castleRight = false;
                    }
                    if (board.IsTileAttacked(board.tiles[i, y], owner))
                    {
                        castleRight = false;
                    }
                    i += 1;
                }
                if (castleRight)
                {
                    lst.Add(position + new Vector3(2, 0));
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

        lst.Add(position + new Vector3(0, 1));
        lst.Add(position + new Vector3(1, 1));
        lst.Add(position + new Vector3(1, 0));
        lst.Add(position + new Vector3(0, -1));
        lst.Add(position + new Vector3(-1, 0));
        lst.Add(position + new Vector3(-1, 1));
        lst.Add(position + new Vector3(1, -1));
        lst.Add(position + new Vector3(-1, -1));

        List<Vector3> removalList = new List<Vector3>();
        foreach (Vector3 pos in lst)
        {
            if (pos.x < 0 || pos.x >= board.cols || pos.y < 0 || pos.y >= board.rows)
            {
                removalList.Add(pos);
            }
            else if (board.tiles[(int)pos.x, (int)pos.y].GetContents() != null &&
                board.tiles[(int)pos.x, (int)pos.y].GetContents().GetOwner() == owner)
            {
                removalList.Add(pos);
            }
            //This does not include pos that the king cannot move bc threat
        }

        foreach (Vector3 pos in removalList)
        {
            lst.Remove(pos);
        }

        return lst;
    }

}
