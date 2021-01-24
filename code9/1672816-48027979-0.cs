    public static Point ToPoint(this UITestControl control)
    {
        var point = new Point(control.BoundingRectangle.X + control.BoundingRectangle.Width / 2,
            control.BoundingRectangle.Y + control.BoundingRectangle.Height / 2);
        return point;
    }
