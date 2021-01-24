    public class ExtendedFrameRenderer : FrameRenderer
    {
      public override void Draw(CGRect rect)
    {           
        var gl = new CAGradientLayer
        {
            StartPoint = new CGPoint(0, 0),
            EndPoint = new CGPoint(1, 1),
            Frame = rect,
            Colors = new CGColor[]
            {
                    //old
                    //_gradinetControl.StartColor.ToCGColor(),
                    // _gradinetControl.EndColor.ToCGColor()
                    //fix
                    ToCGColor(__gradinetControl.StartColor),
                    ToCGColor(__gradinetControl.EndColor)
            },
            CornerRadius = _gradinetControl.CornerRadius
        };
       NativeView.Layer.BackgroundColor = UIColor.Clear.CGColor;
       NativeView.Layer.InsertSublayer(gl,0);           
       base.Draw(rect);
    }
        public static CGColor ToCGColor(Color color)
        {
            return new CGColor(CGColorSpace.CreateSrgb(), new nfloat[] { (float)color.R, (float)color.G, (float)color.B, (float)color.A });
        }
    }
