using HMUI;
using UnityEngine;

namespace BetterPause.UI
{
	public class ImageContentBehaviour : MonoBehaviour
	{
		private NoTransitionsButton _button;
		private ImageView _image;
		internal Color Default { get; set; }
		internal Color Hover { get; set; }
		private void Start()
		{
			_button = GetComponent<NoTransitionsButton>();
			_image = transform.Find("BG").GetComponent<ImageView>();
		}

		private void Update()
		{
			_image.color = _button.selectionState == NoTransitionsButton.SelectionState.Highlighted ? Hover : Default;
		}
	}
}