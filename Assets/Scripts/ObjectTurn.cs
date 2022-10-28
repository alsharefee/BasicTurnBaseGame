using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ObjectTurn : MonoBehaviour
{
    public UnityEvent OnThisObjectTurn;
    public UnityEvent OnThisObjectEndTurn;
    internal void ActiveTurn()
    {
        OnThisObjectTurn.Invoke();
    }

    internal void EndTurn()
    {
        OnThisObjectEndTurn.Invoke();
    }
}