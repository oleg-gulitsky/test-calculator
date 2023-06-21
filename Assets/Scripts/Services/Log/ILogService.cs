using System;
using System.Text;

namespace Services.Log
{
  public interface ILogService
  {
    StringBuilder GetLogString();
    void AddEntry(string newLog);
    void SaveLog();
    event Action<StringBuilder> LogUpdate;
  }
}