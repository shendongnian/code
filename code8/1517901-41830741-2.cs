    private System.Drawing.Point[] ToPointsArray(List<IntPoint> points)
    {
        System.Drawing.Point[] array = new System.Drawing.Point[points.Count];
        int i = 0;
        foreach (IntPoint p in points)
        {
            array[i++] = new System.Drawing.Point(p.X, p.Y);
        }
        return array;
    }
