	public class RoundButton : Button
	{
		public RoundButton()
		{
			DefaultStyleKey = typeof(RoundButton);
		}
		protected override void OnRender(DrawingContext dc)
		{
			double radius = 10;
			double borderThickness = 1; // Could get this value from any of the this.BorderThickness values
			dc.DrawRoundedRectangle(Background, new Pen(BorderBrush, borderThickness), new Rect(0, 0, Width, Height), radius, radius);
		}
	}
