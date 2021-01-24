    public class CustomPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            var size = new Size();
            if (double.IsInfinity(availableSize.Width)) // availableSize may be infinite
            {
                availableSize.Width = RenderSize.Width;
            }
            if (Children.Count > 0)
            {
                var cellWidth = availableSize.Width / Children.Count;
                var childSize = new Size(cellWidth, cellWidth);
                foreach (var child in Children)
                {
                    child.Measure(childSize);
                }
                size.Width = availableSize.Width;
                size.Height = cellWidth;
            }
            return size;
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            var size = new Size();
            if (Children.Count > 0)
            {
                var cellWidth = finalSize.Width / Children.Count;
                var childRect = new Rect(0, 0, cellWidth, cellWidth);
                foreach (var child in Children)
                {
                    child.Arrange(childRect);
                    childRect.X += cellWidth;
                }
                size.Width = finalSize.Width;
                size.Height = cellWidth;
            }
            return size;
        }
    }
