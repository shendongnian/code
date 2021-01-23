    Point mdown = Point.Empty;
    List<DataPoint> selectedPoints = null;
    private void chart1_MouseDown(object sender, MouseEventArgs e)
    {
        mdown = e.Location;
        selectedPoints = new List<DataPoint>();
    }
    private void chart1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            chart1.Refresh();
            using (Graphics g = chart1.CreateGraphics())
                g.DrawRectangle(Pens.Red, GetRectangle(mdown, e.Location));
        }
    }
    private void chart1_MouseUp(object sender, MouseEventArgs e)
    {
        Axis ax = chart1.ChartAreas[0].AxisX;
        Axis ay = chart1.ChartAreas[0].AxisY;
        Rectangle rect = GetRectangle(mdown, e.Location);
        foreach (DataPoint dp in chart1.Series[0].Points)
        {
            int x = (int)ax.ValueToPixelPosition(dp.XValue);
            int y = (int)ay.ValueToPixelPosition(dp.YValues[0]);
            if (rect.Contains(new Point(x,y))) selectedPoints.Add(dp);
        }
        // optionally color the found datapoints:
        foreach (DataPoint dp in chart1.Series[0].Points)
            dp.Color = selectedPoints.Contains(dp) ? Color.Red : Color.Black;
    }
    static public Rectangle GetRectangle(Point p1, Point p2)
    {
        return new Rectangle(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y),
            Math.Abs(p1.X - p2.X), Math.Abs(p1.Y - p2.Y));
    }
