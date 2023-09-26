using BetterPause.Providers;
using BetterPause.UI;
using HMUI;
using IPA.Utilities;
using SiraUtil.Affinity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using static PlayerSaveData;

namespace BetterPause.Patches
{
	internal class SetDataPatch : IAffinity
	{
		private ColorResolver _colorResolver;
		public SetDataPatch(ColorResolver colorResolver)
		{
			_colorResolver = colorResolver;
		}

		[AffinityPostfix]
		[AffinityPatch(typeof(LevelBar), nameof(LevelBar.Setup), AffinityMethodType.Normal, null, typeof(IPreviewBeatmapLevel), typeof(BeatmapCharacteristicSO), typeof(BeatmapDifficulty))]
		public void Postfix(LevelBar __instance, IPreviewBeatmapLevel previewBeatmapLevel)
		{
			Plugin.Log.Debug("Setting up...");
			var transform = __instance.transform;

			var bg = transform.Find("BG").GetComponent<ImageView>();
			var cover = transform.Find("SongArtwork").GetComponent<ImageView>();

			var buttons = transform.parent.Find("Buttons");
			var menu = buttons.Find("BackButton").gameObject;
			var res = buttons.Find("RestartButton").gameObject;
			var con = buttons.Find("ContinueButton").gameObject;

			var IForgor = buttons.parent.parent.Find("IFUIContainer");
			if(IForgor != null)
			{
				IForgor = IForgor.Find("IFUIBackground");
			}

			Update(previewBeatmapLevel, bg, cover, menu, res, con, __instance._songNameText, __instance._authorNameText, __instance._difficultyText, __instance._characteristicIconImageView, IForgor?.GetComponent<ImageView>());
		}

		internal void Update(IPreviewBeatmapLevel level, ImageView bgImage, ImageView coverImage, GameObject menuButton, GameObject restartButton, GameObject continueButton, TMP_Text songText, TMP_Text authorText, TMP_Text diffText, ImageView diffImage, ImageView IForgorBg)
		{
			bgImage._skew = 0.18f;
			bgImage.overrideSprite = null;
			bgImage.gradient = true;
			bgImage.color = new Color(1f, 1f, 1f, 0.97f);
			bgImage.rectTransform.anchorMin = new Vector2(-0.04f, 0.5f);

			coverImage._skew = 0.18f;
			coverImage.material = Resources.FindObjectsOfTypeAll<Material>().FirstOrDefault(x => x.name == "UINoGlowRoundEdge");
			var rect = coverImage.rectTransform;
			rect.sizeDelta = new Vector2(13.5f, 13.5f);
			rect.anchorMin = new Vector2(0.01f, rect.anchorMin.y);

			var menuContent = menuButton.gameObject.AddComponent<ImageContentBehaviour>();
			var restartContent = restartButton.gameObject.AddComponent<ImageContentBehaviour>();
			var continueContent = continueButton.gameObject.AddComponent<ImageContentBehaviour>();

			(bgImage.color0, bgImage.color1) = _colorResolver.GetBackgroundGradient(true);
			bgImage._gradientDirection = PluginConfig.Instance.BackgroundGradientDirection;

			songText.color = _colorResolver.GetSongNameColor();
			authorText.color = _colorResolver.GetAuthorColor();
			authorText.text = _colorResolver.GetAuthorString(level.levelAuthorName, level.songAuthorName);
			authorText.richText = true;

			(diffImage.color, diffText.color) = _colorResolver.GetDiffColor();

			_colorResolver.UpdateMenuButton(menuContent);
			_colorResolver.UpdateRestartButton(restartContent);
			_colorResolver.UpdateContinueButton(continueContent);

			if (IForgorBg != null)
			{
				IForgorBg.gradient = true;
				IForgorBg.color = Color.white.ColorWithAlpha(0.8f);
				IForgorBg.gameObject.SetActive(PluginConfig.Instance.EnableIForgorIntegration && _colorResolver.IForgorInstalled);
				IForgorBg._gradientDirection = PluginConfig.Instance.IForgorGradientDirection;
				(IForgorBg.color0, IForgorBg._color1) = _colorResolver.GetIForgorGradient();
			}
		}
	}
}
