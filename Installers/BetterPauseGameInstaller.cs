using BetterPause.Patches;
using BetterPause.Providers;
using Zenject;

namespace BetterPause.Installers
{
	internal class BetterPauseGameInstaller : Installer
	{
		public override void InstallBindings()
		{
			Container.Bind<ColorResolver>().AsSingle().NonLazy();
			Container.BindInterfacesTo<SetDataPatch>().AsSingle();
		}
	}
}
