using UnityEngine;

public class SwitcherModel 
{
    private Material _highlightMaterial;
    private Material _defaultMaterial;
    private Renderer _objectRenderer;
    private Transform _transform;
    private float _stepValue;


    public SwitcherModel(Renderer objectRenderer, Material highlightMaterial, Transform transform, float stepValue)
    {
        _objectRenderer = objectRenderer;
        _defaultMaterial = objectRenderer.sharedMaterial;
        _highlightMaterial = highlightMaterial;
        _transform = transform;
        _stepValue = stepValue;
    }

    public void Highlight()
    {
        _objectRenderer.material = _highlightMaterial;
    }

    public void UnHighlight()
    {
        _objectRenderer.material = _defaultMaterial;
    }

    public void SetZRotation(float zRotation)
    {
        Quaternion rotation = Quaternion.Euler(_transform.rotation.eulerAngles.x, _transform.rotation.eulerAngles.y, zRotation);
        _transform.rotation = rotation;
    }

    public Transform GetRotation() => _transform;
    public float GetStepValue() => _stepValue;
}
