using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
{
    override public List<Vector3> GetValidMoves(Board board)
    {
        List<Vector3> lst = new List<Vector3>(); // lst = List of available legal moves
        Transform transform = GetComponentInParent<Transform>();
        Vector3 position = transform.position - board.transform.position;
        int x = (int)position.x;
        int y = (int)position.y;

        // Bishop movement:

        int i = 1;
        while (x + i < board.cols && y + i < board.rows)
        {
            if (board.tiles[x + i, y + i].GetContents() is Empty)
            {
                lst.Add(position + new Vector3(i, i));
            }
            else if (board.tiles[x + i, y + i].GetContents().GetOwner() != owner)
            {
                lst.Add(position + new Vector3(i, i));
                break;
            }
            else { break; }
            i += 1;
        }
        i = 1;
        while (x + i < board.cols && y - i >= 0)
        {
            if (board.tiles[x + i, y - i].GetContents() is Empty)
            {
                lst.Add(position + new Vector3(i, -i));
            }
            else if (board.tiles[x + i, y - i].GetContents().GetOwner() != owner)
            {
                lst.Add(position + new Vector3(i, -i));
                break;
            }
            else { break; }
            i += 1;
        }
        i = 1;
        while (x - i >= 0 && y + i < board.rows)
        {
            if (board.tiles[x - i, y + i].GetContents() is Empty)
            {
                lst.Add(position + new Vector3(-i, i));
            }
            else if (board.tiles[x - i, y + i].GetContents().GetOwner() != owner)
            {
                lst.Add(position + new Vector3(-i, i));
                break;
            }
            else { break; }
            i += 1;
        }
        i = 1;
        while (x - i >= 0 && y - i >= 0)
        {
            if (board.tiles[x - i, y - i].GetContents() is Empty)
            {
                lst.Add(position + new Vector3(-i, -i));
            }
            else if (board.tiles[x - i, y - i].GetContents().GetOwner() != owner)
            {
                lst.Add(position + new Vector3(-i, -i));
                break;
            }
            else { break; }
            i += 1;
        }

        // Rook movement:

        i = 1;
        while (y + i < board.rows)
        {

            if (board.tiles[x, y + i].GetContents() is Empty)
            {
                lst.Add(position + new Vector3(0, i));
            }
            else if (board.tiles[x, y + i].GetContents().GetOwner() != owner)
            {
                lst.Add(position + new Vector3(0, i));
                break;
            }
            else { break; }

            i += 1;

        }

        i = 1;
        while (y - i >= 0)
        {

            if (board.tiles[x, y - i].GetContents() is Empty)
            {
                lst.Add(position + new Vector3(0, -i));
            }
            else if (board.tiles[x, y - i].GetContents().GetOwner() != owner)
            {
                lst.Add(position + new Vector3(0, -i));
                break;
            }
            else { break; }

            i += 1;

        }

        i = 1;
        while (x + i < board.cols)
        {
            if (board.tiles[x + i, y].GetContents() is Empty)
            {
                lst.Add(position + new Vector3(i, 0));
            }
            else if (board.tiles[x + i, y].GetContents().GetOwner() != owner)
            {
                lst.Add(position + new Vector3(i, 0));
                break;
            }
            else { break; }

            i += 1;

        }

        i = 1;
        while (x - i >= 0)
        {
            if (board.tiles[x - i, y].GetContents() is Empty)
            {
                lst.Add(position + new Vector3(-i, 0));
            }
            else if (board.tiles[x - i, y].GetContents().GetOwner() != owner)
            {
                lst.Add(position + new Vector3(-i, 0));
                break;
            }
            else { break; }

            i += 1;

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

        // Bishop movement:

        int i = 1;
        while (x + i < board.cols && y + i < board.rows)
        {
            if (board.tiles[x + i, y + i].GetContents() is Empty)
            {
                lst.Add(position + new Vector3(i, i));
            }
            else
            {
                lst.Add(position + new Vector3(i, i));
                break;
            }
            i += 1;
        }
        i = 1;
        while (x + i < board.cols && y - i >= 0)
        {
            if (board.tiles[x + i, y - i].GetContents() is Empty)
            {
                lst.Add(position + new Vector3(i, -i));
            }
            else
            {
                lst.Add(position + new Vector3(i, -i));
                break;
            }
            i += 1;
        }
        i = 1;
        while (x - i >= 0 && y + i < board.rows)
        {
            if (board.tiles[x - i, y + i].GetContents() is Empty)
            {
                lst.Add(position + new Vector3(-i, i));
            }
            else
            {
                lst.Add(position + new Vector3(-i, i));
                break;
            }
            i += 1;
        }
        i = 1;
        while (x - i >= 0 && y - i >= 0)
        {
            if (board.tiles[x - i, y - i].GetContents() is Empty)
            {
                lst.Add(position + new Vector3(-i, -i));
            }
            else
            {
                lst.Add(position + new Vector3(-i, -i));
                break;
            }
            i += 1;
        }

        // Rook movement:

        i = 1;
        while (y + i < board.rows)
        {

            if (board.tiles[x, y + i].GetContents() is Empty)
            {
                lst.Add(position + new Vector3(0, i));
            }
            else
            {
                lst.Add(position + new Vector3(0, i));
                break;
            }
            i += 1;

        }

        i = 1;
        while (y - i >= 0)
        {

            if (board.tiles[x, y - i].GetContents() is Empty)
            {
                lst.Add(position + new Vector3(0, -i));
            }
            else
            {
                lst.Add(position + new Vector3(0, -i));
                break;
            }

            i += 1;

        }

        i = 1;
        while (x + i < board.cols)
        {
            if (board.tiles[x + i, y].GetContents() is Empty)
            {
                lst.Add(position + new Vector3(i, 0));
            }
            else
            {
                lst.Add(position + new Vector3(i, 0));
                break;
            }

            i += 1;

        }

        i = 1;
        while (x - i >= 0)
        {
            if (board.tiles[x - i, y].GetContents() is Empty)
            {
                lst.Add(position + new Vector3(-i, 0));
            }
            else
            {
                lst.Add(position + new Vector3(-i, 0));
                break;
            }

            i += 1;

        }


        return lst;
    }
}
