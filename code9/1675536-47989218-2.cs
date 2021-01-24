    public class WrapLayout : Layout<View>
    {
        public List<string> ItemSource
        {
            get { return (List<string>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }
        public static readonly BindableProperty ItemSourceProperty =
            BindableProperty.Create
            (
                "ItemSource",
                typeof(List<string>),
                typeof(WrapLayout),
                propertyChanged: (bindable, oldvalue, newvalue) => ((WrapLayout)bindable).AddViews()
            );
        void AddViews()
        {
            Children.Clear();
            foreach (string s in ItemSource)
            {
                Label label = new Label();
                label.BackgroundColor = Color.Red;
                label.Text = s;
                label.TextColor = Color.Black;
                Children.Add(label);
            }
        }
        public static readonly BindableProperty SpacingProperty =
            BindableProperty.Create
            (
                "Spacing",
                typeof(double),
                typeof(WrapLayout),
                10.0,
                propertyChanged: (bindable, oldvalue, newvalue) => ((WrapLayout)bindable).OnSizeChanged()
            );
        public double Spacing
        {
            get { return (double)GetValue(SpacingProperty); }
            set { SetValue(SpacingProperty, value); }
        }
        private void OnSizeChanged()
        {
            this.ForceLayout();
        }
        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            if (WidthRequest > 0)
                widthConstraint = Math.Min(widthConstraint, WidthRequest);
            if (HeightRequest > 0)
                heightConstraint = Math.Min(heightConstraint, HeightRequest);
            double internalWidth = double.IsPositiveInfinity(widthConstraint) ? double.PositiveInfinity : Math.Max(0, widthConstraint);
            double internalHeight = double.IsPositiveInfinity(heightConstraint) ? double.PositiveInfinity : Math.Max(0, heightConstraint);
            return DoHorizontalMeasure(internalWidth, internalHeight);
        }
        private SizeRequest DoHorizontalMeasure(double widthConstraint, double heightConstraint)
        {
            int rowCount = 1;
            double width = 0;
            double height = 0;
            double minWidth = 0;
            double minHeight = 0;
            double widthUsed = 0;
            foreach (var item in Children)
            {
                var size = item.Measure(widthConstraint, heightConstraint);
                height = Math.Max(height, size.Request.Height);
                var newWidth = width + size.Request.Width + Spacing;
                if (newWidth > widthConstraint)
                {
                    rowCount++;
                    widthUsed = Math.Max(width, widthUsed);
                    width = size.Request.Width;
                }
                else
                    width = newWidth;
                minHeight = Math.Max(minHeight, size.Minimum.Height);
                minWidth = Math.Max(minWidth, size.Minimum.Width);
            }
            if (rowCount > 1)
            {
                width = Math.Max(width, widthUsed);
                height = (height + Spacing) * rowCount - Spacing; // via MitchMilam 
            }
            return new SizeRequest(new Size(width, height), new Size(minWidth, minHeight));
        }
        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            double rowHeight = 0;
            double yPos = y, xPos = x;
            foreach (var child in Children.Where(c => c.IsVisible))
            {
                var request = child.Measure(width, height);
                double childWidth = request.Request.Width;
                double childHeight = request.Request.Height;
                rowHeight = Math.Max(rowHeight, childHeight);
                if (xPos + childWidth > width)
                {
                    xPos = x;
                    yPos += rowHeight + Spacing;
                    rowHeight = 0;
                }
                var region = new Rectangle(xPos, yPos, childWidth, childHeight);
                LayoutChildIntoBoundingRegion(child, region);
                xPos += region.Width + Spacing;
            }
        }
    }
