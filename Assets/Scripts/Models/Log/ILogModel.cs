using System;
using System.Text;

namespace Models.Log
{
  public interface ILogModel
  {
    StringBuilder GetLogString();
    void AddEntry(string newLog);
    void SaveLog();
    event Action<StringBuilder> LogUpdate;
  }
}