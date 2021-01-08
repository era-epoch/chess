using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    override public List<Vector3> GetValidMoves(Board board)
    {
        List<Vector3> lst = new List<Vector3>(); // lst = List of available legal moves
        Transform transform = GetComponentInParent<Transform>();
        Vector3 position = transform.position - board.transform.position;
        int x = (int)position.x;
        int y = (int)position.y;

        if (x > 1)
        {
            if (y > 0)
            {
                if (board.tiles[x - 2, y - 1].GetContents() is Empty | board.tiles[x - 2, y - 1].GetContents().GetOwner() != owner)
                {
                    lst.Add(position + new Vector3(-2, -1));
                }
            }
            if (y < 7)
            {
                if (board.tiles[x - 2, y + 1].GetContents() is Empty | board.tiles[x - 2, y + 1].GetContents().GetOwner() != owner)
                {
                    lst.Add(position + new Vector3(-2, 1));
                }
            }
        }
        if (x > 0)
        {
            if (y > 1)
            {
                if (board.tiles[x - 1, y - 2].GetContents() is Empty | board.tiles[x - 1, y - 2].GetContents().GetOwner() != owner)
                {
                    lst.Add(position + new Vector3(-1, -2));
                }
            }
            if (y < 6)
            {
                if (board.tiles[x - 1, y + 2].GetContents() is Empty | board.tiles[x - 1, y + 2].GetContents().GetOwner() != owner)
                {
                    lst.Add(position + new Vector3(-1, 2));
                }
            }
        }
        if (x < 7)
        {
            if (y < 6)
            {
                if (board.tiles[x + 1, y + 2].GetContents() is Empty | board.tiles[x + 1, y + 2].GetContents().GetOwner() != owner)
                {
                    lst.Add(position + new Vector3(1, 2));
                }
            }
            if (y > 1)
            {
                if (board.tiles[x + 1, y - 2].GetContents() is Empty | board.tiles[x + 1, y - 2].GetContents().GetOwner() != owner)
                {
                    lst.Add(position + new Vector3(1, -2));
                }
            }
        }
        if (x < 6)
        {
            if (y < 7)
            {
                if (board.tiles[x + 2, y + 1].GetContents() is Empty | board.tiles[x + 2, y + 1].GetContents().GetOwner() != owner)
                {
                    lst.Add(position + new Vector3(2, 1));
                }
            }
            if (y > 0)
            {
                if (board.tiles[x + 2, y - 1].GetContents() is Empty | board.tiles[x + 2, y - 1].GetContents().GetOwner() != owner)
                {
                    lst.Add(position + new Vector3(2, -1));
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

        if (x > 1)
        {
            if (y > 0)
            {
                lst.Add(position + new Vector3(-2, -1));
            }
            if (y < 7)
            {
                lst.Add(position + new Vector3(-2, 1));
            }
        }
        if (x > 0)
        {
            if (y > 1)
            {
                lst.Add(position + new Vector3(-1, -2));
            }
            if (y < 6)
            {
                lst.Add(position + new Vector3(-1, 2));
            }
        }
        if (x < 7)
        {
            if (y < 6)
            {
                lst.Add(position + new Vector3(1, 2));
            }
            if (y > 1)
            {
                lst.Add(position + new Vector3(1, -2));
            }
        }
        if (x < 6)
        {
            if (y < 7)
            {
                lst.Add(position + new Vector3(2, 1));
            }
            if (y > 0)
            {
                lst.Add(position + new Vector3(2, -1));
            }
        }

        return lst;
    }
}
