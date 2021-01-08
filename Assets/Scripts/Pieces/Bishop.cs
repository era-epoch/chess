﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    override public List<Vector3> GetValidMoves(Board board)
    {
        List<Vector3> lst = new List<Vector3>(); // lst = List of available legal moves
        Transform transform = GetComponentInParent<Transform>();
        Vector3 position = transform.position - board.transform.position;
        int x = (int)position.x;
        int y = (int)position.y;


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


        return lst;
    }


}
