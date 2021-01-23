    PointF transformed(Point p0, bool back)
    {
        Matrix m = matrix.Clone();
        if (back)  m.Invert(); 
        var pt = new Point[] { p0 };
        m.TransformPoints(pt);
        return pt[0];
    }
