    public class DynamicView : LinearLayout
    {
        private List<LinearLayout> layouts;
        int count;
        public DynamicView(Context context, int count) :
            base(context)
        {
            this.count = count;
        }
        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);
            this.Initialize(count);
            
                foreach (var l in this.layouts)
                {
                    l.LayoutParameters = new LinearLayout.LayoutParams(w / this.layouts.Count, ViewGroup.LayoutParams.WrapContent);
                }
        }
        
        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            //call the render logic in OnDraw
            FillView();
        }
        private void Initialize(int count)
        {
            //initialize logic
            this.Orientation = Orientation.Horizontal;
            this.SetBackgroundColor(new Color(0, 125, 0));
            layouts = new List<LinearLayout>();
        }
        //render logic
        private void FillView()
        {
            for (int n = 0; n < count; n++)
            {
                var layout = new LinearLayout(this.Context)
                {
                    Orientation = Orientation.Vertical,
                    Background = new ColorDrawable(new Color(0, 10, 0)),
                    LayoutParameters =
                        new LinearLayout.LayoutParams(this.Width / count, ViewGroup.LayoutParams.WrapContent)
                };
                layouts.Add(layout);
                var button = new Button(this.Context)
                {
                    Text = "New button"
                };
                button.SetBackgroundColor(new Color(125, 0, 0));
                layout.AddView(button);
                this.AddView(layout);
            }
        }
    }
