    public class UniformStackPanel : StackPanel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            var childSize = Orientation == Orientation.Horizontal ?
                new Size(availableSize.Width / Children.Count, availableSize.Height) :
                new Size(availableSize.Width, availableSize.Height / Children.Count);
            double alongAxis = 0;
            double crossAxis = 0;
            foreach (var child in Children)
            {
                child.Measure(childSize);
                if (Orientation == Orientation.Horizontal)
                {
                    alongAxis += child.DesiredSize.Width;
                    crossAxis = Math.Max(crossAxis, child.DesiredSize.Height);
                }
                else
                {
                    alongAxis += child.DesiredSize.Height;
                    crossAxis = Math.Max(crossAxis, child.DesiredSize.Width);
                }
            }
            return Orientation == Orientation.Horizontal ?
                new Size(alongAxis, crossAxis) :
                new Size(crossAxis, alongAxis);
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            var childSize = Orientation == Orientation.Horizontal ?
                new Size(finalSize.Width / Children.Count, finalSize.Height) :
                new Size(finalSize.Width, finalSize.Height / Children.Count);
            double alongAxis = 0;
            foreach (var child in Children)
            {
                if (Orientation == Orientation.Horizontal)
                {
                    child.Arrange(new Rect(alongAxis, 0, childSize.Width, childSize.Height));
                    alongAxis += childSize.Width;
                }
                else
                {
                    child.Arrange(new Rect(0, alongAxis, childSize.Width, childSize.Height));
                    alongAxis += childSize.Height;
                }
            }
            return finalSize;
        }
    }
