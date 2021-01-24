cs
using UnityEngine;
using UnityEngine.UI;
public static class UIX
{
	/// <summary>
	/// Forces the layout of a UI GameObject and all of it's children to update
	/// their positions and sizes.
	/// </summary>
	/// <param name="xform">
	/// The parent transform of the UI GameObject to update the layout of.
	/// </param>
	public static void UpdateLayout(Transform xform)
	{
		Canvas.ForceUpdateCanvases();
		UpdateLayout_Internal(xform);
	}
	private static void UpdateLayout_Internal(Transform xform)
	{
		if (xform == null || xform.Equals(null))
		{
			return;
		}
		// Update children first
		for (int x = 0; x < xform.childCount; ++x)
		{
			UpdateLayout_Internal(xform.GetChild(x));
		}
		// Update any components that might resize UI elements
		foreach (var layout in xform.GetComponents<LayoutGroup>())
		{
			layout.CalculateLayoutInputVertical();
			layout.CalculateLayoutInputHorizontal();
		}
		foreach (var fitter in xform.GetComponents<ContentSizeFitter>())
		{
			fitter.SetLayoutVertical();
			fitter.SetLayoutHorizontal();
		}
	}
}
Use it like this:
cs
UIX.UpdateLayout(canvasTransform); // This canvas contains the scroll rect
scrollRect.verticalNormalizedPosition = 0f;
