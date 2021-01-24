    public partial class DrawLine : UIView
    {
        CGPath pathtotal;
        CGPath path;
        CGPoint initialPoint;
        CGPoint latestPoint;
        public DrawLine(IntPtr handle) : base(handle)
        {
            BackgroundColor = UIColor.White;
            pathtotal = new CGPath();
        }
        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
            path = new CGPath();
            UITouch touch = touches.AnyObject as UITouch;
            if (touch != null)
            {
                initialPoint = touch.LocationInView(this);
            }
        }
        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            base.TouchesMoved(touches, evt);
            UITouch touch = touches.AnyObject as UITouch;
            if (touch != null)
            {
                latestPoint = touch.LocationInView(this);
                SetNeedsDisplay();
            }
        }
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            if (!initialPoint.IsEmpty)
            {
                //get graphics context
                using (CGContext g = UIGraphics.GetCurrentContext())
                {
                    //set up drawing attributes
                    g.SetLineWidth(2);
                    UIColor.Black.SetStroke();
                    //add lines to the touch points
                    if (path.IsEmpty)
                    {
                        path.AddLines(new CGPoint[] { initialPoint, latestPoint });
                    }
                    else
                    {
                        path.AddLineToPoint(latestPoint);
                    }
                    //add geometry to graphics context and draw it
                    pathtotal.AddPath(path);
                    g.AddPath(pathtotal);
                    g.DrawPath(CGPathDrawingMode.Stroke);
                }
            }
        }
    }
