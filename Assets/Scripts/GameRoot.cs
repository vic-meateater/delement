using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private ConfigSO config;

    private SwitcherModel _switcherModel;
    private CalculationsModel _calculatorModel;

    private SwitcherView _switcherView;
    private MultimeterView _multimeterView;
      
    private SwitcherController _switcherController;
    private CalculationsController _calculationsController;

    private Vector3 _spawnCoordiantes = new(-0.25f, 0.5f, 0f);


    void Start()
    {
        _multimeterView = Instantiate(config.MultimeterView);
        var multimeter = Instantiate(config.Multimeter, _spawnCoordiantes, Quaternion.identity);
        _switcherView = multimeter.GetComponentInChildren<SwitcherView>();
        var valueViews = GetValueViewList(multimeter);

        var render = _switcherView.GetComponentInParent<Renderer>();
        var switcherTransform = _switcherView.transform.parent;
        _switcherModel = new SwitcherModel(render, config.HighlightMaterial, switcherTransform, config.StepValue);
        _calculatorModel = new CalculationsModel(config.RValue, config.PValue);

        _switcherController = new SwitcherController(_switcherModel, _switcherView);
        _calculationsController = new CalculationsController(_calculatorModel, _multimeterView, valueViews);

    }

    private List<IValueView> GetValueViewList(GameObject multimeter)
    {
        List<IValueView> list = new();
        list.AddRange(multimeter.GetComponentsInChildren<IValueView>());
        return list;
    }

    void Update()
    {
        //тут раздаем апдейты, всем нуждающимся контроллерам
    }
}
