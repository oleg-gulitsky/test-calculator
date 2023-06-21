using Services.Count;
using Services.Input;
using Services.Log;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
  public override void InstallBindings()
  {
    Container.BindInterfacesAndSelfTo<LogService>().AsSingle();
    Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
    Container.BindInterfacesAndSelfTo<CountService>().AsSingle();
  }
}