using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggeredEventListener : MonoBehaviour
{
    public UnityEvent whatHappens;
    public TriggeredEvent whichEvent;

    private void OnEnable()
    {
        whichEvent.Subscribe(this);
    }

    private void OnDisable()
    {
        whichEvent.Unsubscribe(this);
    }

    public void EventTriggered()
    {
        whatHappens.Invoke();
    }

}
