    public class ColumnPanel : Panel
    {
        public double ViewportHeight
        {
            get { return (double)GetValue(ViewportHeightProperty); }
            set { SetValue(ViewportHeightProperty, value); }
        }
        public static readonly DependencyProperty ViewportHeightProperty =
            DependencyProperty.Register("ViewportHeight", typeof(double), typeof(ColumnPanel),
                new FrameworkPropertyMetadata(double.PositiveInfinity, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));
        protected override Size MeasureOverride(Size constraint)
        {
            var location = new Point(0, 0);
            var size = new Size(0, 0);
            foreach (UIElement child in Children)
            {
                child.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                if (location.Y != 0 && ViewportHeight < location.Y + child.DesiredSize.Height)
                {
                    location.X = size.Width;
                    location.Y = 0;
                }
                if (size.Width < location.X + child.DesiredSize.Width)
                    size.Width = location.X + child.DesiredSize.Width;
                if (size.Height < location.Y + child.DesiredSize.Height)
                    size.Height = location.Y + child.DesiredSize.Height;
                location.Offset(0, child.DesiredSize.Height);
            }
            return size;
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            var location = new Point(0, 0);
            var size = new Size(0, 0);
            foreach (UIElement child in Children)
            {
                if (location.Y != 0 && ViewportHeight < location.Y + child.DesiredSize.Height)
                {
                    location.X = size.Width;
                    location.Y = 0;
                }
                child.Arrange(new Rect(location, child.DesiredSize));
                if (size.Width < location.X + child.DesiredSize.Width)
                    size.Width = location.X + child.DesiredSize.Width;
                if (size.Height < location.Y + child.DesiredSize.Height)
                    size.Height = location.Y + child.DesiredSize.Height;
                location.Offset(0, child.DesiredSize.Height);
            }
            return size;
        }
    }
