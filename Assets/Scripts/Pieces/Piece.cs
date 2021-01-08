using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public string owner;
    public bool hasMoved = false;
    public List<StatusCondition> conditions = new List<StatusCondition>();


    public virtual void TurnUpdate()
    {
        List<StatusCondition> removalList = new List<StatusCondition>();
        
        foreach(StatusCondition status in conditions)
        {
            status.AddTurns(-1);
            if (status.turns <= 0)
            {
                removalList.Add(status);
            }
            else
            {
                status.StatusEffect(this);
            }
        }

        foreach(StatusCondition status in removalList)
        {
            conditions.Remove(status);
        }

    }

    public bool CheckCondition<T>()
    {
        foreach(StatusCondition status in conditions)
        {
            if (status is T)
            {
                return true;
            }
        }
        return false;
    }

    public void SetOwner(string name)
    {
        this.owner = name;
    }

    public string GetOwner()
    {
        return this.owner;
    }

    public virtual List<Vector3> GetValidMoves(Board board)
    {
        List<Vector3> lst = new List<Vector3>();
        return lst;
    }

    public virtual List<Vector3> GetAttacks(Board board)
    {
        List<Vector3> lst = new List<Vector3>();
        return lst;
    }

    public void LimitMovesInCheck(List<Vector3> moves, Board board)
    {
        List<Vector3> removals = new List<Vector3>();
        
        foreach(Vector3 move in moves)
        {
            if (board.TryMoveForCheck(this, move)){
                removals.Add(move);
            }
        }

        foreach(Vector3 move in removals)
        {
            moves.Remove(move);
        }
    }


    private void OnMouseOver()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }

    private void OnMouseExit()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    public void SetStatus(StatusCondition status)
    {
        this.conditions.Add(status);
    }

}
