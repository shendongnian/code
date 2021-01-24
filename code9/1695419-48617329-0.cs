	public class ProgressView : UIView
	{
		CAShapeLayer progressLayer;
		UILabel label;
		public ProgressView() { Setup(); }
		public ProgressView(Foundation.NSCoder coder) : base(coder) { Setup(); }
		public ProgressView(Foundation.NSObjectFlag t) : base(t) { Setup(); }
		public ProgressView(IntPtr handle) : base(handle) { }
		public ProgressView(CGRect frame) : base(frame) { Setup(); }
		void Setup()
		{
			BackgroundColor = UIColor.Clear;
			Layer.CornerRadius = 25;
			Layer.BorderWidth = 10;
			Layer.BorderColor = UIColor.Blue.CGColor;
			Layer.BackgroundColor = UIColor.Cyan.CGColor;
			progressLayer = new CAShapeLayer()
			{
				FillColor = UIColor.Red.CGColor,
				Frame = Bounds
			};
			Layer.AddSublayer(progressLayer);
			label = new UILabel(Bounds)
			{
				TextAlignment = UITextAlignment.Center,
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear,
				Font = UIFont.FromName("ChalkboardSE-Bold", 20)
			};
			InsertSubview(label, 100);
		}
		double complete;
		public double Complete
		{
			get { return complete; }
			set { complete = value; label.Text = $"{value * 100} %"; SetNeedsDisplay(); }
		}
		public override void Draw(CGRect rect)
		{
			base.Draw(rect);
			var progressWidth = (rect.Width - (Layer.BorderWidth * 2)) * complete;
			var progressRect = new CGRect(rect.X + Layer.BorderWidth, rect.Y + Layer.BorderWidth, progressWidth, (rect.Height - Layer.BorderWidth * 2));
			progressLayer.Path = UIBezierPath.FromRoundedRect(progressRect, 25).CGPath;
		}
	}
