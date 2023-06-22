using System;
using UnityEngine;

namespace Models.InputString
{
  public class InputStringModel : IInputStringModel
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

    public string GetEntry() =>
      _currentString + "=" + GetResult();

    private string GetResult()
    {
      const string error = "ERROR";
      
      string[] values = _currentString.Split("+");

      if (values.Length != 2)
        return error;

      if (!int.TryParse(values[0], out int value1))
        return error;
      
      if (!int.TryParse(values[1], out int value2))
        return error;

      return (value1 + value2).ToString();
    }
  }
}