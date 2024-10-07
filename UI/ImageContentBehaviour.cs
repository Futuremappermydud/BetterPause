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
		internal bool InGame { get; set; }
		private (float, float) yVals = (1f, 0f);
		private void Start()
		{
			_button = GetComponent<NoTransitionsButton>();
			_image = transform.Find("BG").GetComponent<ImageView>();
		}

		private void OnEnable()
		{
			if (!InGame || !_button) return;
			var pos = _button.transform.localPosition;
			pos.y = yVals.Item2;
			_button.transform.localPosition = pos;
		}

		private void Update()
		{
			_image.color = _button.selectionState == NoTransitionsButton.SelectionState.Highlighted ? Hover : Default;
			if (!InGame || !_button) return;
			var pos = _button.transform.localPosition;
			pos.y = Mathf.Lerp(pos.y, _button.selectionState == NoTransitionsButton.SelectionState.Highlighted ? yVals.Item1 : yVals.Item2, Time.deltaTime * 6f);
			_button.transform.localPosition = pos;
		}
	}
}