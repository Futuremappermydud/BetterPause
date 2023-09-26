﻿using BetterPause.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BetterPause.Providers
{
	public class ColorResolver
	{
		private PluginConfig config => PluginConfig.Instance;

		public bool IForgorInstalled
		{
			get
			{
				return IPA.Loader.PluginManager.GetPluginFromId("I Forgor") != null;
			}
		}
		public (Color, Color) GetBackgroundGradient(bool inGame = false)
		{
			var color0 = config.EnableBackgroundGradient ? config.BackgroundGradientColor2 : new Color(0.68f, 0.57f, 0f, 1f);
			var color1 = config.EnableBackgroundGradient ? config.BackgroundGradientColor1 : new Color(0.68f, 0.57f, 0f, 0.94f);
			return inGame ? (color1, color0) : (color0, color1);
		}

		public (Color, Color) GetIForgorGradient()
		{
			Color color0;
			Color color1;
			if (config.EnableIForgorIntegration)
			{
				if (config.SyncColorsFromMainBackground)
				{
					color0 = config.FlipSyncedColors ? config.BackgroundGradientColor1 : config.BackgroundGradientColor2;
					color1 = config.FlipSyncedColors ? config.BackgroundGradientColor2 : config.BackgroundGradientColor1;
				}
				else
				{
					color0 = config.IForgorGradientColor1;
					color1 = config.IForgorGradientColor2;
				}
			}
			else
			{
				color0 = Color.black;
				color1 = Color.black;
			}
			return (color0, color1);
		}

		public (Color, Color) GetDiffColor()
		{
			var color = config.EnableDiffColor ? config.DiffColor: Color.white.ColorWithAlpha(0.75f);
			return (color, color);
		}

		public Color GetAuthorColor() => config.EnableAuthorNameColor ? config.AuthorNameColor : Color.white.ColorWithAlpha(0.75f);
		public Color GetSongNameColor() => config.EnableSongNameColor ? config.SongNameColor : Color.white;

		public string GetAuthorString(string mapper, string author)
		{
			if (!string.IsNullOrWhiteSpace(mapper) && config.EnableMapperName)
			{
				var mapperHex = config.EnableMapperNameColor ? ColorUtility.ToHtmlStringRGBA(config.MapperNameColor) : "ff69b4";

				return $"<size=80%>{author}</size> <size=90%>[<color=#{mapperHex}>{mapper.Replace(@"<", "<\u200B").Replace(@">", ">\u200B")}</color>]</size>";
			}
			else
			{
				return author;
			}
		}

		public void UpdateMenuButton(ImageContentBehaviour content) => UpdateButton(content, config.CustomButtonColorMenuDefault, config.CustomButtonColorMenuHover);
		public void UpdateRestartButton(ImageContentBehaviour content) => UpdateButton(content, config.CustomButtonColorRestartDefault, config.CustomButtonColorRestartHover);
		public void UpdateContinueButton(ImageContentBehaviour content) => UpdateButton(content, config.CustomButtonColorContinueDefault, config.CustomButtonColorContinueHover);

		private void UpdateButton(ImageContentBehaviour content, Color def, Color hov)
		{
			content.enabled = config.EnableCustomButtonColors;
			content.Default = def;
			content.Hover = hov;
		}
	}
}
