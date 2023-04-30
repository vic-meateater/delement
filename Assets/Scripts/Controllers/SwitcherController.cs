using System;
using UnityEngine;


public class SwitcherController: IDisposable
{
    private const int OFFSET = 10;
    private SwitcherModel _model;
    private SwitcherView _view;

    public SwitcherController(SwitcherModel model, SwitcherView view)
    {
        _model = model;
        _view = view;
        _view.MouseEnterEvent += OnMouseEnter;
        _view.MouseExitEvent += OnMouseExit;
        _view.MouseOverEvent += OnMouseScroll;
    }

    private void OnMouseEnter()
    {
        _model.Highlight();
    }

    private void OnMouseExit()
    {
        _model.UnHighlight();
    }

    private void OnMouseScroll(float scrollValue)
    {
        float delta = scrollValue * OFFSET * _model.GetStepValue();
        Vector3 rotation = _model.GetRotation().eulerAngles;
        _model.SetZRotation(rotation.z + delta); 
        Transform switcherTranform = _view.transform.parent;
        switcherTranform.rotation = _model.GetRotation().rotation;
    }

    public void Dispose()
    {
        _view.MouseEnterEvent -= OnMouseEnter;
        _view.MouseExitEvent -= OnMouseExit;
        _view.MouseOverEvent -= OnMouseScroll;
    }
}
