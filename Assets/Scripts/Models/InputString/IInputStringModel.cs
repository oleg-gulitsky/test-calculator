using System;

namespace Models.InputString
{
  public interface IInputStringModel
  {
    void UpdateInputString(string inputString);
    string GetInputString();
    void SaveInputString();
    void ClearInputString();
    string GetEntry();
    event Action ClearInput;
  }
}