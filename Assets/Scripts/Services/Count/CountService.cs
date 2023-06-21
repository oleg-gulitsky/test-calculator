using Services.Input;
using Services.Log;
using Zenject;

namespace Services.Count
{
  public class CountService : ICountService
  {
    private ILogService _logService;
    private IInputService _inputService;

    [Inject]
    public void Construct(IInputService inputService, ILogService logService)
    {
      _logService = logService;
      _inputService = inputService;
    }

    public void Calculate()
    {
      string inputString = _inputService.GetInputString();
      
      if(inputString == "")
        return;

      string entry = inputString + "=" + GetResult(inputString);

      _logService.AddEntry(entry);
      
      _inputService.ClearInputString();
    }
    
    private static string GetResult(string currentString)
    {
      const string error = "ERROR";
      
      string[] values = currentString.Split("+");

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