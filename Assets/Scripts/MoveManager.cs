using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "MoveManager")]
public class MoveManager : ScriptableObject
{

    int movesLeft;
    bool isPlayersTurn = true;

    public int MovesPerTurn;
    public TriggeredEvent updateMoveCounterEvent;
    public TriggeredEvent endTurn;
    public string enemyTurnText;
    public string playerTurnText;

    public void UseMove()
    {
        movesLeft--;
        if (movesLeft == 0)
        {
            isPlayersTurn = false;
            endTurn.Trigger();
        }
        updateMoveCounterEvent.Trigger();

    }

    public bool CanMove()
    {
        return movesLeft > 0 && isPlayersTurn;
    }
    
    public void NewTurn()
    {
        movesLeft = MovesPerTurn;
        isPlayersTurn = true;
        updateMoveCounterEvent.Trigger();
    }

    public void AddMoves(int howMany)
    {
        movesLeft += howMany;
        updateMoveCounterEvent.Trigger();
    }

    public string MoveStatus()
    {
        return isPlayersTurn ? (movesLeft + playerTurnText) : enemyTurnText;
    }

}
