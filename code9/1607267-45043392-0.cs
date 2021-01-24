    protected override Size MeasureOverride(Size availableSize)
    {
        var measuredSize = new Size();
        foreach (UIElement element in base.InternalChildren)
        {
            element.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            var elementSize = element.DesiredSize;
            measuredSize.Width = Math.Max(measuredSize.Width, elementSize.Width);
            measuredSize.Height = Math.Max(measuredSize.Height, elementSize.Height);
        }
        return measuredSize;
    }
