    /// <summary>
    /// Rotates the specified point around another center.
    /// </summary>
    /// <param name="center">Center point to rotate around.</param>
    /// <param name="pt">Point to rotate.</param>
    /// <param name="degree">Rotation degree. A value between 1 to 360.</param>
    public static Point RotatePoint(Point center, Point pt, float degree)
    {
        double x1, x2, y1, y2;
        x1 = center.X;
        y1 = center.Y;
        x2 = pt.X;
        y2 = pt.Y;
        double distance = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        degree *= (float)(Math.PI / 180);
        double x3, y3;
        x3 = distance * Math.Cos(degree) + x1;
        y3 = distance * Math.Sin(degree) + y1;
        return new Point((int)x3, (int)y3);
    }
