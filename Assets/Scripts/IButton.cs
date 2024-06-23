using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IButton : Interactable
{
    public UnityEvent Event;

    override public void OnInteract()
    {
        Event.Invoke();
    }
}
