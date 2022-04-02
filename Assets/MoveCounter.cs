using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveCounter : MonoBehaviour
{
    public MoveManager moveManager;
    [SerializeField] TextMeshProUGUI text;
    
    public void UpdateMoveCounter()
    {
        text.text = moveManager.MoveStatus();
    }
}
