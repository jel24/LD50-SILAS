using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoyBlocker : MonoBehaviour
{
    public AbilityManager abilityManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            abilityManager.ToggleDecoy(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            abilityManager.ToggleDecoy(true);
        }
    }
}
