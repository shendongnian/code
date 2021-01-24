    public class StretchPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            Size size = new Size(0, 0);
            foreach (UIElement child in Children)
            {
                child.Measure(availableSize);
                size.Width += child.DesiredSize.Width;
                size.Height = Math.Max(size.Height, child.DesiredSize.Height);
            }
            size.Width = double.IsInfinity(availableSize.Width) ?
               size.Width : availableSize.Width;
            size.Height = double.IsInfinity(availableSize.Height) ?
               size.Height : availableSize.Height;
            return size;
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            double total = 0;
            foreach (UIElement child in Children) total += child.DesiredSize.Width;
            double x = 0;
            double factor = Math.Max(finalSize.Width / total,1);
            foreach (UIElement child in Children)
            {
                double adjusted_width = child.DesiredSize.Width * factor;
                child.Arrange(new Rect(x, 0, adjusted_width, finalSize.Height));
                x += adjusted_width;
            }
            return finalSize;
        }
    }
