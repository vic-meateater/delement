using System;
using UnityEngine;

public class SwitcherView : MonoBehaviour
{
    public event Action MouseEnterEvent;
    public event Action MouseExitEvent;
    public event Action<float> MouseOverEvent;

    private void OnMouseEnter()
    {
        MouseEnterEvent?.Invoke();
    }

    private void OnMouseExit()
    {
        MouseExitEvent?.Invoke();
    }

    private void OnMouseOver()
    {
        float scrollValue = Input.GetAxis("Mouse ScrollWheel");
        if (scrollValue > 0 || scrollValue < 0)
            MouseOverEvent?.Invoke(scrollValue);
    }

}
