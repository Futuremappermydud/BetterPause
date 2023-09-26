using HMUI;
using IPA.Config.Stores;
using IPA.Config.Stores.Attributes;
using IPA.Config.Stores.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace BetterPause
{
	internal class PluginConfig
	{
		//Too lazy to zenject
		public static PluginConfig Instance { get; set; }

		//General
		public virtual bool Enabled { get; set; } = true;
		public virtual bool EnableMapperName { get; set; } = true;

		//Background
		public virtual bool EnableBackgroundGradient { get; set; } = false;
		[UseConverter(typeof(HexColorConverter))]
		public virtual Color BackgroundGradientColor1 { get; set; } = Color.yellow;
		[UseConverter(typeof(HexColorConverter))]
		public virtual Color BackgroundGradientColor2 { get; set; } = Color.yellow;
		[UseConverter(typeof(EnumConverter<ImageView.GradientDirection>))]
		public virtual ImageView.GradientDirection BackgroundGradientDirection { get; set; } = ImageView.GradientDirection.Horizontal;

		//Text
		public virtual bool EnableSongNameColor { get; set; } = false;
		[UseConverter(typeof(HexColorConverter))]
		public virtual Color SongNameColor { get; set; } = Color.white;
		public virtual bool EnableAuthorNameColor { get; set; } = false;
		[UseConverter(typeof(HexColorConverter))]
		public virtual Color AuthorNameColor { get; set; } = Color.gray;
		public virtual bool EnableMapperNameColor { get; set; } = false;
		[UseConverter(typeof(HexColorConverter))]
		public virtual Color MapperNameColor { get; set; } = new Color(1f, 0.4f, 0.7f);
		public virtual bool EnableDiffColor { get; set; } = false;
		[UseConverter(typeof(HexColorConverter))]
		public virtual Color DiffColor { get; set; } = new Color(1f, 1f, 1f).ColorWithAlpha(0.75f);

		//Custom Button Colors
		public virtual bool EnableCustomButtonColors { get; set; } = false;
		[UseConverter(typeof(HexColorConverter))]
		public virtual Color CustomButtonColorMenuDefault { get; set; } = new Color(0.125f, 0.125f, 0.125f);
		[UseConverter(typeof(HexColorConverter))]
		public virtual Color CustomButtonColorMenuHover { get; set; } = new Color(1f, 0.14f, 0.9f);
		[UseConverter(typeof(HexColorConverter))]
		public virtual Color CustomButtonColorRestartDefault { get; set; } = new Color(0.125f, 0.125f, 0.125f);
		[UseConverter(typeof(HexColorConverter))]
		public virtual Color CustomButtonColorRestartHover { get; set; } = new Color(1f, 0.14f, 0.9f);
		[UseConverter(typeof(HexColorConverter))]
		public virtual Color CustomButtonColorContinueDefault { get; set; } = new Color(0.125f, 0.125f, 0.125f);
		[UseConverter(typeof(HexColorConverter))]
		public virtual Color CustomButtonColorContinueHover { get; set; } = new Color(1f, 0.14f, 0.9f);

		//IForgor Integration
		public virtual bool EnableIForgorIntegration { get; set; } = false;
		public virtual bool SyncColorsFromMainBackground { get; set; } = false;
		public virtual bool FlipSyncedColors { get; set; } = false;
		[UseConverter(typeof(HexColorConverter))]
		public Color IForgorGradientColor1 { get; set; } = Color.gray.ColorWithAlpha(0.5f);
		[UseConverter(typeof(HexColorConverter))]
		public Color IForgorGradientColor2 { get; set; } = Color.gray.ColorWithAlpha(0.5f);
		[UseConverter(typeof(EnumConverter<ImageView.GradientDirection>))]
		public virtual ImageView.GradientDirection IForgorGradientDirection { get; set; } = ImageView.GradientDirection.Horizontal;

		public virtual void Changed()
		{

		}
	}
}
