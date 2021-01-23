    public class MyGestureListener : GestureDetector.SimpleOnGestureListener
    {
        OverlayBox box;
        public void SetBox(OverlayBox box)
        {
            this.box = box;
        }
        public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
        {
            Console.WriteLine($"OnFling velocityX={velocityX} velocityY={velocityY}");
            if (e2.RawY < e1.RawY) //add more constraints on X
            {
                Rectangle r = box.Bounds;
                r.Top = - r.Height;
                box.LayoutTo(r, 500);
            }
            //for fun
            Task.Delay(1000).ContinueWith(_ =>
            {
                    Rectangle r1 = box.Bounds;
                    r1.Top = 0;
                    box.LayoutTo(r1, 500);
            }); 
            return base.OnFling(e1, e2, velocityX, velocityY);
        }
    }
    class OverlayBoxRenderer : ViewRenderer<OverlayBox, Android.Views.View>
    {
        private readonly GestureDetector _detector;
        private readonly MyGestureListener _listener;
        public OverlayBoxRenderer()
        {
            _listener = new MyGestureListener();
            _detector = new GestureDetector(_listener);
        }
        protected override void OnElementChanged(ElementChangedEventArgs<OverlayBox> e)
        {
            if (e.NewElement == null)
            {
                this.Touch -= HandleTouch;
            }
            if (e.OldElement == null)
            {
                _listener.SetBox(e.NewElement);
                this.Touch += HandleTouch;
            }
        }
        void HandleTouch(object sender, TouchEventArgs e)
        {
            _detector.OnTouchEvent(e.Event);
        }
      
    }
