using UnityEngine;

public class CalculationsModel
{
    private float _rValue;
    private float _pValue;

    public CalculationsModel(float RValue, float PValue) 
    {
        _rValue = RValue;
        _pValue = PValue;
    }

    public float GetRValue()
    {
        return _rValue;
    }

    public float GetAValue()
    {
        return Mathf.Sqrt(_pValue / _rValue);
    }

    public float GetVValue()
    {
        return Mathf.Sqrt(_pValue * _rValue);
    }

    public float GetACValue() => 0.01f;
    public float GetZeroValue() => 0f;
}
