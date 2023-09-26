using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;
using HMUI;
using Zenject;

namespace BetterPause.UI
{
	internal class BetterPauseFlowCoordinator : FlowCoordinator
	{
		private BetterPauseView _view;

		public override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
		{
			if (firstActivation)
			{
				SetTitle("Better Pause");
				showBackButton = true;
				ProvideInitialViewControllers(_view);
			}
		}

		[Inject]
		internal void Construct(BetterPauseView view)
		{
			_view = view;
			MenuButtons.instance.RegisterButton(
				new MenuButton("Better Pause", () =>
				{
					BeatSaberUI.MainFlowCoordinator.PresentFlowCoordinator(this);
				}
			));
		}

		public override void BackButtonWasPressed(ViewController topViewController)
		{
			BeatSaberUI.MainFlowCoordinator.DismissFlowCoordinator(this);
		}
	}
}
