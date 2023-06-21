using System;

namespace Services.Input
{
  public interface IInputService
  {
    void UpdateInputString(string inputString);
    string GetInputString();
    void SaveInputString();
    void ClearInputString();
    event Action ClearInput;
  }
}