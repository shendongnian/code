    e.Graphics.ResetTransform();
    for (int i = 0; i < Points.Count; i++)
    {
        Point[] pts = new Point[] { Point.Round(transformed(Points[i], false)) };  
        Rectangle rc = new Rectangle(pts[0], new Size(19, 19));
        e.Graphics.DrawRectangle(Pens.Red, rc);
    }
