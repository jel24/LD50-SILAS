using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "AbilityManager")]
public class AbilityManager : ScriptableObject
{

    public MoveManager moveManager;
    public TriggeredEvent useSprint;
    public TriggeredEvent useDecoy;

    public int sprintsLeft = 2;
    public int decoysLeft = 1;

    public bool CanUseSprint()
    {
        return sprintsLeft > 0;
    }

    public void Sprint()
    {
        moveManager.AddMoves(3);
        sprintsLeft--;
        useSprint.Trigger();

    }

    public bool CanUseDecoy()
    {
        return decoysLeft > 0;
    }

    public void Decoy()
    {
        decoysLeft--;
        useDecoy.Trigger();

    }

    public int GetDecoysLeft()
    {
        return decoysLeft;
    }

    public int GetSprintsLeft()
    {
        return sprintsLeft;
    }
}
