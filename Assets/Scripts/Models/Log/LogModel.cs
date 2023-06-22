using System;
using System.Text;
using UnityEngine;

namespace Models.Log
{
  public class LogModel : ILogModel
  {
    private const string LOG = "log";
    
    private StringBuilder _log;

    public event Action<StringBuilder> LogUpdate;

    public StringBuilder GetLogString()
    {
      if (_log != null)
        return _log;
      
      _log = new StringBuilder(PlayerPrefs.GetString(LOG, ""));
      return _log;
    }

    public void AddEntry(string entry)
    {
      _log.Insert(0, $"{entry}\n");
      UpdateLog();
    }

    private void UpdateLog() =>
      LogUpdate?.Invoke(_log);

    public void SaveLog() =>
      PlayerPrefs.SetString(LOG, _log.ToString());
  }
}