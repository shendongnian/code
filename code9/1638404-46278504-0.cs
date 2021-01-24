    public class CustomImage : Image
	{
		public CustomImage() : base()
		{
			const int _animationTime = 10;
			var iconTap = new TapGestureRecognizer();
			iconTap.Tapped += async (sender, e) =>
			{
				try
				{
					var btn = (CustomImage)sender;
					await btn.ScaleTo(5, _animationTime);
					//await btn.ScaleTo(1, _animationTime);
				}
				catch (Exception ex)
				{
					ex.Track();
				}
			};
		}
	}
