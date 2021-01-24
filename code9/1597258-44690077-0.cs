    public class TextLayout:FrameLayout
    {
        private TextView headerLabel;
        public TextLayout(Context context) : base(context)
        {
            //put the initialization codes in contructor
                UpdateText();
                if (this.headerLabel.Parent == null)
                {
                    this.AddView(this.headerLabel);
                }
        }
        
        private void UpdateText()
        {
            if (headerLabel == null)
                this.headerLabel = new TextView(this.Context);
            headerLabel.LayoutParameters = (new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent));
            this.headerLabel.Text = "General Meeting";
            headerLabel.SetTextColor(Color.Green);
            headerLabel.Typeface = Typeface.DefaultBold;
            headerLabel.TextSize = 25;
        }
        
        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            int minimumWidth = this.PaddingLeft + PaddingRight + SuggestedMinimumWidth;
            int widthOfLayout = ResolveSizeAndState(minimumWidth, widthMeasureSpec, 1);
            SetMeasuredDimension(widthOfLayout, 75);
        }
    }
