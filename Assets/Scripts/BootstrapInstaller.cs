using Models.InputString;
using Models.Log;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
  public override void InstallBindings()
  {
    Container.BindInterfacesAndSelfTo<LogModel>().AsSingle();
    Container.BindInterfacesAndSelfTo<InputStringModel>().AsSingle();
  }
}