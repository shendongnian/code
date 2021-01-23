	public class CustomButton : UIButton
	{
		public CustomButton() { }
		public CustomButton(IntPtr handle) : base(handle) { }
		public CustomButton(NSObjectFlag t) : base(t) { }
		public override void LayoutSublayersOfLayer(CoreAnimation.CALayer layer)
		{
			base.LayoutSublayersOfLayer(layer);
		}
	}
