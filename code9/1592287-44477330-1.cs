	public class RoundedBox : UIView
	{
		public RoundedBox()
		{
		}
		public RoundedBox(Foundation.NSCoder coder) : base(coder)
		{
		}
		public RoundedBox(Foundation.NSObjectFlag t) : base(t)
		{
		}
		public RoundedBox(IntPtr handle) : base(handle)
		{
		}
		public RoundedBox(CoreGraphics.CGRect frame) : base(frame)
		{
		}
		public override void Draw(CGRect rect)
		{
			var rectanglePath = UIBezierPath.FromRoundedRect(rect, 50.0f);
			UIColor.Red.SetFill();
			rectanglePath.Fill();
		}
	}
