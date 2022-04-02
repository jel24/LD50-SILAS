using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "TriggeredEvent")]

public class TriggeredEvent : ScriptableObject
{
    List<TriggeredEventListener> listeners = new List<TriggeredEventListener>();

    public void Subscribe(TriggeredEventListener l)
    {
        if (!listeners.Contains(l))
            listeners.Add(l);

    }

    public void Unsubscribe(TriggeredEventListener l)
    {
        if (listeners.Contains(l))
            listeners.Remove(l);
    }

    public void Trigger()
    {
        for (int i = listeners.Count-1; i >= 0; i--)
        {
            listeners[i].EventTriggered();
        }
    }
}
