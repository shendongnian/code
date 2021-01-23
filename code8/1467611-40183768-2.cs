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
            if (e2.RawY < e1.RawY)
            {
                Rectangle r = box.Bounds;
                r.Bottom = 0;
                r.Top = r.Bottom - r.Height;
                box.LayoutTo(r, 500);
            }
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
