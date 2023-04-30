using System;
using System.Collections.Generic;
using TMPro;

public class CalculationsController: IDisposable
{
    private List<IValueView> _valueViews;
    private CalculationsModel _calcModel;
    private MultimeterView _multimeterView;
    private List<TextMeshProUGUI> _textValues = new();

    public CalculationsController(CalculationsModel calculationsModel, MultimeterView multimeterView, List<IValueView> valueViews)
    {
        _valueViews = valueViews;
        _calcModel = calculationsModel;
        _multimeterView = multimeterView;

        foreach (IValueView valueView in _valueViews)
        {
            valueView.ColliderTriggerEnter += OnValueViewColliderTriggerEnter;
            //valueView.ColliderTriggerExit += OnValueViewColliderTriggerExit;
            //»з задани€ не пон€л, когда нужно обнул€ть. ≈сли раскоментировать 21 строку и закоментировать 52, 
            //то значени€ будут обнул€тьс€ при выходе из триггера.
        }
    }


    private void OnValueViewColliderTriggerEnter(IValueView valueView)
    {
        _textValues.Clear();
        _textValues.Add(_multimeterView.DisplayText);
        switch (valueView)
        {
            case VValueView:
                _textValues.Add(_multimeterView.VTextValue);
                ShowDisplayText(_textValues, _calcModel.GetVValue());
                break;
            case RValueView:
                _textValues.Add(_multimeterView.RTextValue);
                ShowDisplayText(_textValues, _calcModel.GetRValue(),"");
                break;
            case AValueView:
                _textValues.Add(_multimeterView.ATextValue);
                ShowDisplayText(_textValues, _calcModel.GetAValue());
                break;
            case ACValueView:
                _textValues.Add(_multimeterView.ACTextValue);
                ShowDisplayText(_textValues, _calcModel.GetACValue());
                break;
            case ZeroValueView:
                _textValues.Clear();
                SetValuesToZero();
                ShowDisplayText(_calcModel.GetZeroValue(),"");
                break;
            default:
                break;
        }
    }
    private void OnValueViewColliderTriggerExit(IValueView valueView)
    {
        SetValuesToZero();
    }

    private void ShowDisplayText(List<TextMeshProUGUI> textValues, float value, string formatter = "F2")
    {
        foreach(var textValue in textValues)
        {
            textValue.text = value.ToString(formatter);
        }
    }

    private void ShowDisplayText(float value, string formatter = "F2")
    {
        _multimeterView.DisplayText.text = value.ToString(formatter);
    }

    private void SetValuesToZero()
    {
        foreach (var value in _multimeterView.TextValues)
        {
            value.text = _calcModel.GetZeroValue().ToString();
        }
    }

    public void Dispose()
    {
        foreach (IValueView valueView in _valueViews)
        {
            valueView.ColliderTriggerEnter -= OnValueViewColliderTriggerEnter;
            valueView.ColliderTriggerExit -= OnValueViewColliderTriggerExit;
        }
    }
}
