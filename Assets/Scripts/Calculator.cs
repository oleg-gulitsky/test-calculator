using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
  [SerializeField] private TMP_InputField _inputField;
  [SerializeField] private TMP_Text _logText;
  [SerializeField] private Button _button;
  
  public event Action OnButtonClick;
  public event Action<string> OnInputValueChanged;

  public void SetInputString(string s) =>
    _inputField.text = s;

  public void ClearInputString() =>
    _inputField.text = null;

  public void SetLogString(StringBuilder s) =>
    _logText.SetText(s);
  
  private void OnEnable()
  {
    _button.onClick.AddListener(OnButtonClickHandler);
    _inputField.onValueChanged.AddListener(OnInputValueChangedHandler);
  }

  private void OnDisable()
  {
    _button.onClick.RemoveListener(OnButtonClickHandler);
    _inputField.onValueChanged.RemoveListener(OnInputValueChangedHandler);
  }

  private void OnButtonClickHandler() =>
    OnButtonClick?.Invoke();

  private void OnInputValueChangedHandler(string value) =>
    OnInputValueChanged?.Invoke(value);
}