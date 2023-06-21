using Services.Count;
using Services.Input;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
  [RequireComponent(typeof(TMP_InputField))]
  public class Input : MonoBehaviour
  {
    private TMP_InputField _inputField;
    private ICountService _countService;
    private IInputService _inputService;

    [Inject]
    public void Construct(IInputService inputService)
    {
      _inputService = inputService;
    }
    
    private void OnEnable()
    {
      _inputField = GetComponent<TMP_InputField>();

      _inputService.ClearInput += ClearInputHandler;
      _inputField.onValueChanged.AddListener(OnValueChangedHandler);

      _inputField.text = _inputService.GetInputString();
    }

    private void OnDisable()
    {
      _inputService.SaveInputString();
      
      _inputService.ClearInput -= ClearInputHandler;
      _inputField.onValueChanged.RemoveListener(OnValueChangedHandler);
    }

    private void OnValueChangedHandler(string value) =>
      _inputService.UpdateInputString(value);

    private void ClearInputHandler() =>
      _inputField.text = null;
  }
}