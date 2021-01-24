    public class SqueezeStackPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            var desiredHeight = 0.0;
            foreach (UIElement child in InternalChildren)
            {
                child.Measure(availableSize);
                desiredHeight += child.DesiredSize.Height;
            }
            if (availableSize.Height < desiredHeight)
            {
                // we will never go out of bounds
                return availableSize;
            }
            return new Size(availableSize.Width, desiredHeight);
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            // measure desired heights of children in case of unconstrained height
            var size = MeasureOverride(new Size(finalSize.Width, double.PositiveInfinity));
            var startHeight = 0.0;
            var squeezeFactor = 1.0;
            // adjust the desired item height to the available height
            if (finalSize.Height < size.Height)
            {
                squeezeFactor = finalSize.Height / size.Height;
            }
            foreach (UIElement child in InternalChildren)
            {
                var allowedHeight = child.DesiredSize.Height * squeezeFactor;
                var area = new Rect(new Point(0, startHeight), new Size(finalSize.Width, allowedHeight));
                child.Arrange(area);
                startHeight += allowedHeight;
            }
            return new Size(finalSize.Width, startHeight);
        }
    }
