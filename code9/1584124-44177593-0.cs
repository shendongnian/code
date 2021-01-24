    private void button1_Click(object sender, EventArgs e)
    {
        rotateSeries(s1, s2, s1.Points[4], 33);
    }
    void rotateSeries(Series src, Series tgt, DataPoint center, float angle)
    {
        Point c = new Point((int)center.XValue, (int)center.YValues[0]);
        tgt.Points.Clear();
        foreach (DataPoint dp in src.Points)
        {
            Point p0 = new Point((int)dp.XValue, (int)dp.YValues[0]);
            PointF p = RotatePoint(p0, c, angle);
            tgt.Points.AddXY(p.X, p.Y);
        }
    }
    static PointF RotatePoint(PointF pointToRotate, PointF centerPoint, double angleInDegrees)
    {
        double angleInRadians = angleInDegrees * (Math.PI / 180);
        double cosTheta = Math.Cos(angleInRadians);
        double sinTheta = Math.Sin(angleInRadians);
        return new PointF
        {
            X = (float)
                (cosTheta * (pointToRotate.X - centerPoint.X) -
                sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X),
            Y = (float)
                (sinTheta * (pointToRotate.X - centerPoint.X) +
                cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y)
        };
    }
