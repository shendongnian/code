    public class MyCanvas : View
    {
        private  ShapeDrawable _shape;
        public MyCanvas(Context context) : this (context, null)
        {
        }
        public MyCanvas(Context context, IAttributeSet attrs) : this (context, attrs, 0)
        {
        }
        public MyCanvas(Context context, IAttributeSet attrs, int defStyle) : base (context, attrs, defStyle)
        {
            Init();
        }
        public void Init() 
        {
            var paint = new Paint();
            paint.SetARGB(255, 200, 255, 0);
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeWidth = 4;
            _shape = new ShapeDrawable(new OvalShape());
            _shape.Paint.Set(paint);
            _shape.SetBounds(20, 20, 300, 200);
        }
        protected override void OnDraw(Canvas canvas)
        {
            _shape.Draw(canvas);
        }
    }
