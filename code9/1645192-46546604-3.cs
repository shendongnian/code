    void FlattenCurveOutside(List<Point> points, float radius)//, int count)
    {
        using (GraphicsPath gp = new GraphicsPath())
        using (GraphicsPath gpc = new GraphicsPath())
        {
            // firt create a path that looks like our circle:
            PointF l = points.Last();
            gpc.AddEllipse(l.X - radius, l.Y - radius, radius * 2, radius* 2);
            // next one that holds the curve:
            gp.AddCurve(points.ToArray());
            // now we flatten it to a not too large number of line segments:
            Matrix m = new Matrix(); // dummy matrix
            gp.Flatten(m, 0.75f);   // <== play with this param!!
            // now we test the pathpoints from bach to front until we have left the circle:
            int k = -1;
            for (int i = gp.PathPoints.Length - 1; i >= 0; i--)
            {
                if ( !gpc.IsVisible(gp.PathPoints[i])) k = i;
                if (k > 0) break;
            }
            // now we know how many pathpoints we want to retain:
            points.Clear();
            for (int i = 1; i <= k; i++)
                 points.Add(Point.Round(gp.PathPoints[i]));
        }
    }
