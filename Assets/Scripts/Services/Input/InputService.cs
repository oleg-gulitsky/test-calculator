using System;
using UnityEngine;

namespace Services.Input
{
  public class InputService : IInputService
  {
    private const string INPUT_STRING = "input_string";

    private string _currentString;
    
    public event Action ClearInput;

    public void UpdateInputString(string inputString) =>
      _currentString = inputString;

    public void SaveInputString() =>
      PlayerPrefs.SetString(INPUT_STRING, _currentString);

    public string GetInputString()
    {
      if (_currentString != null)
        return _currentString;
      
      _currentString = PlayerPrefs.GetString(INPUT_STRING, "");
      return _currentString;
    }

    public void ClearInputString() =>
      ClearInput?.Invoke();
  }
}