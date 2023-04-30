using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class MultimeterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _displayText;
    [SerializeField] private TextMeshProUGUI _vTextValue;
    [SerializeField] private TextMeshProUGUI _aTextValue;
    [SerializeField] private TextMeshProUGUI _acTextValue;
    [SerializeField] private TextMeshProUGUI _rTextValue;

    public List<TextMeshProUGUI> TextValues => new()
    {
        _displayText,
        _vTextValue,
        _aTextValue,
        _acTextValue,
        _rTextValue
    };

    public TextMeshProUGUI DisplayText => _displayText;
    public TextMeshProUGUI VTextValue => _vTextValue;
    public TextMeshProUGUI ATextValue => _aTextValue;
    public TextMeshProUGUI ACTextValue => _acTextValue;
    public TextMeshProUGUI RTextValue => _rTextValue;
}
