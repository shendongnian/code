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
            size.Width = childRect.X;
            size.Height = childRect.Height;
        }
        return size;
    }
