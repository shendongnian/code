    private double GetAngle(List<Pixel> pattern, Rectangle bounds)
    {
        int halfWidth = bounds.X + (bounds.Width / 2);
        int halfHeight = bounds.Y + (bounds.Height / 2);
        double leftEdgeAngle = GetAngleLeftEdge(pattern, halfWidth, halfHeight);
        double rightEdgeAngle = GetAngleRightEdge(pattern, halfWidth, halfHeight);
        if (Math.Abs(leftEdgeAngle - rightEdgeAngle) <= 1.5)
        {
            return (leftEdgeAngle + rightEdgeAngle) / 2d;
        }
        if (Math.Abs(leftEdgeAngle) > Math.Abs(rightEdgeAngle))
        {
            return rightEdgeAngle;
        }
        else
        {
            return leftEdgeAngle;
        }
    }
    private double GetAngleLeftEdge(List<Pixel> pattern, double halfWidth, double halfHeight)
    {
        var topLeftPixels = pattern.Select(p => p.Position).Where(p => p.Y < halfHeight && p.X < halfWidth).ToArray();
        var bottomLeftPixels = pattern.Select(p => p.Position).Where(p => p.Y > halfHeight && p.X < halfWidth).ToArray();
        Point topLeft = topLeftPixels.OrderBy(p => p.X).ThenBy(p => p.Y).First();
        Point bottomLeft = bottomLeftPixels.OrderByDescending(p => p.Y).ThenBy(p => p.X).First();
        int xDiff = bottomLeft.X - topLeft.X;
        int yDiff = bottomLeft.Y - topLeft.Y;
        double angle = Math.Atan2(yDiff, xDiff) * 180 / Math.PI;
        return 90 - angle;
    }
    private double GetAngleRightEdge(List<Pixel> pattern, double halfWidth, double halfHeight)
    {
        var topRightPixels = pattern.Select(p => p.Position).Where(p => p.Y < halfHeight && p.X > halfWidth).ToArray();
        var bottomRightPixels = pattern.Select(p => p.Position).Where(p => p.Y > halfHeight && p.X > halfWidth).ToArray();
        Point topRight = topRightPixels.OrderBy(p => p.Y).ThenByDescending(p => p.X).First();
        Point bottomRight = bottomRightPixels.OrderByDescending(p => p.X).ThenByDescending(p => p.Y).First();
        int xDiff = bottomRight.X - topRight.X;
        int yDiff = bottomRight.Y - topRight.Y;
        double angle = Math.Atan2(xDiff, yDiff) * 180 / Math.PI;
        return Math.Abs(angle);
    }
