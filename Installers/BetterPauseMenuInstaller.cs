using BetterPause.Providers;
using BetterPause.UI;
using Zenject;

namespace BetterPause.Installers
{
	internal class BetterPauseMenuInstaller : Installer
	{
		public override void InstallBindings()
		{
			Container.Bind<ColorResolver>().AsSingle().NonLazy();
			Container.Bind<BetterPauseView>().FromNewComponentAsViewController().AsSingle().NonLazy();
			Container.Bind<BetterPauseFlowCoordinator>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
		}
	}
}
