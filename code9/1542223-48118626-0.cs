    namespace PROJECT
    {
        public class MyFrame : Xamarin.Forms.Frame
        {
            public static float myFrameWidth = 2;
            public static float myCornerRadius = 12;
            public static Color myFrameColor = Color.Red;
            public static Color myBackgroundColor = Color.Black;
    
            public MyFrame() { }
        }
    }
...
    [assembly: ExportRenderer(typeof(PROJECT.MyFrame), typeof(PROJECT.Droid.MyFrameRenderer))]
    namespace PROJECT.Droid
    {
        class MyFrameRenderer : FrameRenderer
        {
            protected override void OnDraw(Android.Graphics.Canvas canvas)
            {
                // canvas contains image of standard outline
                // to "hide" it, not efficent but sometimes "close enough solution"
                // is to overlay that outline by new one in our's page background color
                // then draw a new one in prefered style
                // or... just draw thicker one over the old
    
                var my1stPaint = new Android.Graphics.Paint();
                var my2ndPaint = new Android.Graphics.Paint();
                var backgroundPaint = new Android.Graphics.Paint();
    
                my1stPaint.AntiAlias = true;
                my1stPaint.SetStyle(Paint.Style.Stroke);
                my1stPaint.StrokeWidth = MyFrame.myFrameWidth + 2;
                my1stPaint.Color = MyFrame.myFrameColor.ToAndroid();
    
                my2ndPaint.AntiAlias = true;
                my2ndPaint.SetStyle(Paint.Style.Stroke);
                my2ndPaint.StrokeWidth = MyFrame.myFrameWidth;
                my2ndPaint.Color = MyFrame.myBackgroundColor.ToAndroid();
    
                backgroundPaint.SetStyle(Paint.Style.Stroke);
                backgroundPaint.StrokeWidth = 4;
                backgroundPaint.Color = MyFrame.myBackgroundColor.ToAndroid();
    
                Rect oldBounds = new Rect();
                canvas.GetClipBounds(oldBounds);
    
                RectF oldOutlineBounds = new RectF();
                oldOutlineBounds.Set(oldBounds);
    
                RectF myOutlineBounds = new RectF();
                myOutlineBounds.Set(oldBounds);
                myOutlineBounds.Top += (int)my2ndPaint.StrokeWidth+3;
                myOutlineBounds.Bottom -= (int)my2ndPaint.StrokeWidth+3;
                myOutlineBounds.Left += (int)my2ndPaint.StrokeWidth+3;
                myOutlineBounds.Right -= (int)my2ndPaint.StrokeWidth+3;
    
                canvas.DrawRoundRect(oldOutlineBounds, 10, 10, backgroundPaint); //to "hide" old outline
                canvas.DrawRoundRect(myOutlineBounds, MyFrame.myCornerRadius, MyFrame.myCornerRadius, my1stPaint);
                canvas.DrawRoundRect(myOutlineBounds, MyFrame.myCornerRadius, MyFrame.myCornerRadius, my2ndPaint);
    
                base.OnDraw(canvas);
            }
    
            protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Frame> e)
            {
                base.OnElementChanged(e);
            }
        }
    }
