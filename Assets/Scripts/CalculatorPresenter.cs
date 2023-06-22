using Models.InputString;
using Models.Log;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Calculator))]
public class CalculatorPresenter : MonoBehaviour
{
  private IInputStringModel _inputString;
  private ILogModel _log;
  private Calculator _view;

  [Inject]
  public void Constructor(IInputStringModel inputString, ILogModel log)
  {
    _inputString = inputString;
    _log = log;
  }

  private void OnEnable()
  {
    _view = GetComponent<Calculator>();

    _view.SetInputString(_inputString.GetInputString());
    _view.SetLogString(_log.GetLogString());

    _log.LogUpdate += _view.SetLogString;
    _view.OnInputValueChanged += OnInputValueChangedHandler;
    _view.OnButtonClick += OnButtonClickHandler;
  }

  private void OnDisable()
  {
    _inputString.SaveInputString();
    _log.SaveLog();
    
    _log.LogUpdate -= _view.SetLogString;
    _view.OnInputValueChanged -= OnInputValueChangedHandler;
    _view.OnButtonClick -= OnButtonClickHandler;
  }

  private void OnInputValueChangedHandler(string newValue) =>
    _inputString.UpdateInputString(newValue);

  private void OnButtonClickHandler()
  {
    if(_inputString.GetInputString() == "")
      return;
    
    _log.AddEntry(_inputString.GetEntry());
    _view.ClearInputString();
  }
}