using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "AbilityManager")]
public class AbilityManager : ScriptableObject
{

    public MoveManager moveManager;
    public TriggeredEvent useSprint;
    public TriggeredEvent useDecoy;
    int sprintsLeft;
    int decoysLeft;
    bool canDecoyHere = true;

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
        return decoysLeft > 0 && canDecoyHere;
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

    public void SetAbilityCharges(int sprints, int decoys)
    {
        decoysLeft = decoys;
        sprintsLeft = sprints;
        canDecoyHere = true;
    }

    public void ToggleDecoy(bool onOff)
    {
        canDecoyHere = onOff;
    }
}
