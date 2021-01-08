using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusCondition
{
    public int turns;

    public StatusCondition(int turns)
    {
        this.turns = turns;
    }

    public void AddTurns(int num)
    {
        this.turns += num;
    }

    public virtual void StatusEffect(Piece piece)
    {
        return;
    }

}
