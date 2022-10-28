using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnsManager : MonoBehaviour
{
    [HideInInspector]
    public int turnNumber = 0;

    public int TotalTurns = 0;

    [Tooltip("Turns start from top to down. So hero should be the first.")]
    public ObjectTurn[] objectTurn;

    private void Start()
    {
        objectTurn[0].ActiveTurn();
    }

    public void TurnEnded()
    {
        TotalTurns++;

        objectTurn[turnNumber].EndTurn();

        turnNumber++;
        if (turnNumber >= objectTurn.Length)
            turnNumber = 0;
        objectTurn[turnNumber].ActiveTurn();
    }

}
