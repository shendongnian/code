    public class SquareContentControl : ContentControl
    {
        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            var sizeLimit = Math.Min(arrangeBounds.Width, arrangeBounds.Height);
            if (VisualChildrenCount > 0)
            {
                var child = GetVisualChild(0) as UIElement;
                if (child != null)
                {
                    child.Arrange(new Rect(new Point((arrangeBounds.Width - sizeLimit) / 2, (arrangeBounds.Height - sizeLimit) / 2), new Size(sizeLimit, sizeLimit)));
                    return arrangeBounds;
                }
            }
            return base.ArrangeOverride(arrangeBounds);
        }
        protected override Size MeasureOverride(Size constraint)
        {
            var sizeLimit = Math.Min(constraint.Width, constraint.Height);
            if (VisualChildrenCount > 0)
            {
                var child = GetVisualChild(0) as UIElement;
                if (child != null)
                {
                    child.Measure(new Size(sizeLimit, sizeLimit));
                    return child.DesiredSize;
                }
            }
            return base.MeasureOverride(constraint);
        }
    }
