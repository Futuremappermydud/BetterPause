using BetterPause.Installers;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using SiraUtil.Zenject;
using IPALogger = IPA.Logging.Logger;

namespace BetterPause
{
	[Plugin(RuntimeOptions.SingleStartInit), NoEnableDisable]
	public class Plugin
	{
		internal static Plugin Instance { get; private set; }
		internal static IPALogger Log { get; private set; }

		[Init]
		public Plugin(IPALogger logger, Config conf, Zenjector zenjector)
		{
			Instance = this;
			Log = logger;
			zenjector.Install<BetterPauseMenuInstaller>(Location.Menu);
			zenjector.Install<BetterPauseGameInstaller>(Location.StandardPlayer);
			PluginConfig.Instance = conf.Generated<PluginConfig>();
		}
	}
}
