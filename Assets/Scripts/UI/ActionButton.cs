using Services.Count;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
  [RequireComponent(typeof(Button))]
  public class ActionButton : MonoBehaviour
  {
    private Button _button;
    private ICountService _countService;

    [Inject]
    public void Construct(ICountService countService)
    {
      _countService = countService;
    }
    
    private void OnEnable()
    {
      _button = GetComponent<Button>();
      _button.onClick.AddListener(OnClickHandler);
    }

    private void OnDisable()
    {
      _button.onClick.RemoveListener(OnClickHandler);
    }

    private void OnClickHandler() =>
      _countService.Calculate();
  }
}