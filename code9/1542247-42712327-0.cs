    public class MyTextView:TextView
    {
        public MyTextView(Context c) : base(c)
        {
        }
        public MyTextView(Context c, IAttributeSet attr) : base(c, attr)
        {
        }
        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            int parentWidth=MeasureSpec.GetSize(widthMeasureSpec);
            int parentHeight = MeasureSpec.GetSize(heightMeasureSpec);
            //set the size to the parent layout's cell's size.
            this.SetMeasuredDimension(parentWidth / 2, parentHeight / 4);
        }
    }
