using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum Ability
{
    Sprint,
    Decoy
}

public class AbilityCounter : MonoBehaviour
{
    public AbilityManager abilityManager;
    public Ability whichAbility;
    [SerializeField] TextMeshProUGUI text;
    
    public void UpdateCounter()
    {
        if (whichAbility == Ability.Sprint)
        {
            text.text = "(Q) Sprint:" + abilityManager.GetSprintsLeft();
        } else
        {
            text.text = "(E) Decoy:" + abilityManager.GetDecoysLeft();

        }
    }
}
