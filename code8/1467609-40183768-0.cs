    public class MyGestureListener : GestureDetector.SimpleOnGestureListener
        {
    
            public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
            {
                Console.WriteLine($"OnFling velocityX={velocityX} velocityY={velocityY}");
                return base.OnFling(e1, e2, velocityX, velocityY);
            }
        }
    
    
        class OverlayBoxRenderer : ViewRenderer<OverlayBox, Android.Views.View>
        {
            private readonly GestureDetector _detector;
    
            public OverlayBoxRenderer()
            {
                _detector = new GestureDetector(new MyGestureListener());
            }
    
            protected override void OnElementChanged(ElementChangedEventArgs<OverlayBox> e)
            {
                if (e.NewElement == null)
                {
                    this.Touch -= HandleTouch;
                }
    
                if (e.OldElement == null)
                {
                    this.Touch += HandleTouch;
                }
    
    
            }
    
            void HandleTouch(object sender, TouchEventArgs e)
            {
                _detector.OnTouchEvent(e.Event);
            }
    
          
        }
