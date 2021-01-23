	public class ButtonControlRenderer : ViewRenderer<ButtonControl, Button>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<ButtonControl> e)
		{
			//your creation code ...			
			button.Tapped += OnButtonTapped;
		}
		
		private void OnButtonTapped(...)
		{
			((IButtonController)Element)?.SendClicked();
		}
		
		protected override void Dispose(bool disposing)
		{
			if (Control != null)
				Control.Tapped -= OnButtonTapped;
			base.Dispose(disposing);
		}
	}
