using System;

public interface IValueView
{
    event Action<IValueView> ColliderTriggerEnter;
    event Action<IValueView> ColliderTriggerExit;
}
