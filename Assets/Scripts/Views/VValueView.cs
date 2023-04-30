using System;
using UnityEngine;

public class VValueView : MonoBehaviour, IValueView
{
    public event Action<IValueView> ColliderTriggerEnter;
    public event Action<IValueView> ColliderTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        ColliderTriggerEnter?.Invoke(this);
    }

    private void OnTriggerExit(Collider other)
    {
        ColliderTriggerExit?.Invoke(this);
    }
}
