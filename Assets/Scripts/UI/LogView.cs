using System.Text;
using Services.Log;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
  [RequireComponent(typeof(TMP_Text))]
  public class LogView : MonoBehaviour
  {
    private TMP_Text _content;
    private ILogService _logService;

    [Inject]
    public void Construct(ILogService logService)
    {
      _logService = logService;
    }
    
    private void OnEnable()
    {
      _content = GetComponent<TMP_Text>();
      
      SetLogString(_logService.GetLogString());
      
      _logService.LogUpdate += SetLogString;
    }

    private void OnDisable()
    {
      _logService.SaveLog();
      _logService.LogUpdate -= SetLogString;
    }

    private void SetLogString(StringBuilder newLogString) =>
      _content.SetText(newLogString);
  }
}
