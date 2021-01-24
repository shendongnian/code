    public class MySpecialWrapPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement child in InternalChildren)
            {
                child.Measure(availableSize);
            }
            return new Size();
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            var x = 0d;
            var y = 0d;
            var height = 0d;
            var children = InternalChildren.Cast<UIElement>().ToList();
            while (children.Count > 0)
            {
                var child = children.First();
                if (x > 0d && x + child.DesiredSize.Width > finalSize.Width)
                {
                    // try to find child that fits
                    var fit = children.FirstOrDefault(
                        c => x + c.DesiredSize.Width <= finalSize.Width);
                    child = fit ?? child;
                    if (x + child.DesiredSize.Width > finalSize.Width)
                    {
                        x = 0d;
                        y = height;
                    }
                }
                children.Remove(child);
                child.Arrange(
                    new Rect(x, y, child.DesiredSize.Width, child.DesiredSize.Height));
                x += child.DesiredSize.Width;
                height = Math.Max(height, y + child.DesiredSize.Height);
            }
            return finalSize;
        }
    }
