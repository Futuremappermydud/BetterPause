using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
using BetterPause.Providers;
using HMUI;
using IPA.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Zenject;

namespace BetterPause.UI
{
	[HotReload(RelativePathToLayout = @"BetterPauseView.bsml")]
	[ViewDefinition("BetterPause.UI.BetterPauseView.bsml")]
	internal class BetterPauseView : BSMLAutomaticViewController
	{
		private static PluginConfig config => PluginConfig.Instance;

		[Inject] private ColorResolver _colorResolver;

		[UIValue("direction-options")] private List<object> directionOptions = Enum.GetNames(typeof(ImageView.GradientDirection)).Select(x => (object)x).ToList();

		bool IForgorInstalled => _colorResolver.IForgorInstalled;

		bool Enabled
		{
			get => config.Enabled;
			set
			{
				config.Enabled = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		bool MapperName
		{
			get => config.EnableMapperName;
			set
			{
				config.EnableMapperName = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		bool BgGradient
		{
			get => config.EnableBackgroundGradient;
			set
			{
				config.EnableBackgroundGradient = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		Color BgGradient1
		{
			get => config.BackgroundGradientColor1;
			set
			{
				config.BackgroundGradientColor1 = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		Color BgGradient2
		{
			get => config.BackgroundGradientColor2;
			set
			{
				config.BackgroundGradientColor2 = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		string BackgroundDirection
		{
			get => config.BackgroundGradientDirection.ToString();
			set
			{
				config.BackgroundGradientDirection = (ImageView.GradientDirection)Enum.Parse(typeof(ImageView.GradientDirection), value);
				config.Changed();
				UpdateMockPause();
			}
		}

		bool SongName
		{
			get => config.EnableSongNameColor;
			set
			{
				config.EnableSongNameColor = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		Color SongNameColor
		{
			get => config.SongNameColor;
			set
			{
				config.SongNameColor = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		bool AuthorName
		{
			get => config.EnableAuthorNameColor;
			set
			{
				config.EnableAuthorNameColor = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		Color AuthorNameColor
		{
			get => config.AuthorNameColor;
			set
			{
				config.AuthorNameColor = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		bool CustomMapperName
		{
			get => config.EnableMapperNameColor;
			set
			{
				config.EnableMapperNameColor = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		Color MapperNameColor
		{
			get => config.MapperNameColor;
			set
			{
				config.MapperNameColor = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		bool CustomDiffColor
		{
			get => config.EnableDiffColor;
			set
			{
				config.EnableDiffColor = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		Color DiffColor
		{
			get => config.DiffColor;
			set
			{
				config.DiffColor = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		bool ButtonColors
		{
			get => config.EnableCustomButtonColors;
			set
			{
				config.EnableCustomButtonColors = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		Color MenuDefault
		{
			get => config.CustomButtonColorMenuDefault;
			set
			{
				config.CustomButtonColorMenuDefault = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		Color MenuHover
		{
			get => config.CustomButtonColorMenuHover;
			set
			{
				config.CustomButtonColorMenuHover = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		Color RestartDefault
		{
			get => config.CustomButtonColorRestartDefault;
			set
			{
				config.CustomButtonColorRestartDefault = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		Color RestartHover
		{
			get => config.CustomButtonColorRestartHover;
			set
			{
				config.CustomButtonColorRestartHover = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		Color ContinueDefault
		{
			get => config.CustomButtonColorContinueDefault;
			set
			{
				config.CustomButtonColorContinueDefault = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		Color ContinueHover
		{
			get => config.CustomButtonColorContinueHover;
			set
			{
				config.CustomButtonColorContinueHover = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		bool IForgor
		{
			get => config.EnableIForgorIntegration;
			set
			{
				config.EnableIForgorIntegration = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		bool IForgorSync
		{
			get => config.SyncColorsFromMainBackground;
			set
			{
				config.SyncColorsFromMainBackground = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		bool IForgorFlip
		{
			get => config.FlipSyncedColors;
			set
			{
				config.FlipSyncedColors = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		Color IForgor1
		{
			get => config.IForgorGradientColor1;
			set
			{
				config.IForgorGradientColor1 = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		Color IForgor2
		{
			get => config.IForgorGradientColor2;
			set
			{
				config.IForgorGradientColor2 = value;
				config.Changed();
				UpdateMockPause();
			}
		}

		string IForgorDirection
		{
			get => config.IForgorGradientDirection.ToString();
			set
			{
				config.IForgorGradientDirection = (ImageView.GradientDirection)Enum.Parse(typeof(ImageView.GradientDirection), value);
				config.Changed();
				UpdateMockPause();
			}
		}

		[UIObject("pause-wrapper")] private GameObject _pauseWrapper;
		[UIComponent("pause-img")] private ImageView _pauseImage;

		[UIComponent("name-txt")] private TMP_Text _songText;
		[UIComponent("author-txt")] private TMP_Text _authorText;

		[UIComponent("diff-txt")] private TMP_Text _diffText;
		[UIComponent("diff-img")] private ImageView _diffImage;

		[UIComponent("forgor-example")] private ImageView IForgorBg;

		[UIObject("menu-btn")] private GameObject _menuButton;
		private ImageContentBehaviour _menuContent;
		[UIObject("restart-btn")] private GameObject _restartButton;
		private ImageContentBehaviour _restartContent;
		[UIObject("continue-btn")] private GameObject _continueButton;
		private ImageContentBehaviour _continueContent;

		[UIAction("#post-parse")]
		internal void PostParse()
		{
			if (gameObject.GetComponent<Touchable>() == null)
				gameObject.AddComponent<Touchable>();
			foreach (var x in GetComponentsInChildren<Backgroundable>(true).Select(x => x.GetComponent<ImageView>()))
			{
				if (!x || x.color0 != Color.white || x.sprite.name != "RoundRect10" || x.transform.parent.name != "BSMLTab")
					continue;

				x.SetField("_skew", 0f);
				x.overrideSprite = null;
				x.SetImage("#RoundRect10BorderFade");
				x.color = new Color(1f, 1f, 1f, 0.4f);
			}

			var wrapperImage = _pauseWrapper.GetComponent<ImageView>();
			wrapperImage.SetField("_skew", 0.18f);
			wrapperImage.overrideSprite = null;
			wrapperImage.gradient = true;
			wrapperImage.color = new Color(1f, 1f, 1f, 0.85f);

			_pauseImage.SetField("_skew", 0.18f);
			_pauseImage.material = Resources.FindObjectsOfTypeAll<Material>().FirstOrDefault(x => x.name == "UINoGlowRoundEdge");

			_menuContent = _menuButton.gameObject.AddComponent<ImageContentBehaviour>();
			_restartContent = _restartButton.gameObject.AddComponent<ImageContentBehaviour>();
			_continueContent = _continueButton.gameObject.AddComponent<ImageContentBehaviour>();

			IForgorBg.gradient = true;
			IForgorBg.color = Color.white.ColorWithAlpha(0.8f);

			UpdateMockPause();
		}

		internal void UpdateMockPause()
		{
			if (_pauseWrapper == null) return;

			var wrapperImage = _pauseWrapper.GetComponent<ImageView>();
			(wrapperImage.color0, wrapperImage.color1) = _colorResolver.GetBackgroundGradient();
			wrapperImage._gradientDirection = config.BackgroundGradientDirection;

			_songText.color = _colorResolver.GetSongNameColor();
			_authorText.color = _colorResolver.GetAuthorColor();
			_authorText.text = _colorResolver.GetAuthorString("Mapper", "Song Author");

			(_diffImage.color, _diffText.color) = _colorResolver.GetDiffColor();

			_colorResolver.UpdateMenuButton(_menuContent);
			_colorResolver.UpdateRestartButton(_restartContent);
			_colorResolver.UpdateContinueButton(_continueContent);

			IForgorBg.gameObject.SetActive(config.EnableIForgorIntegration && _colorResolver.IForgorInstalled);
			IForgorBg._gradientDirection = config.IForgorGradientDirection;
			(IForgorBg.color0, IForgorBg._color1) = _colorResolver.GetIForgorGradient();
		}
	}
}
