using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "ProgramConfig", menuName = "Config")]
public class ConfigSO : ScriptableObject
{

    [Header("Prefabs and other setups")]
    public GameObject Multimeter;
    public Material HighlightMaterial;
    public MultimeterView MultimeterView;

    [Header("Multimetr switcher steps")]
    public float StepValue;

    [Header("Value Settings")]
    public float RValue = 1000f;
    public float PValue = 400f;

}
