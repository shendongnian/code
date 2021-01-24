    private void chart1_PostPaint(object sender, ChartPaintEventArgs e)
    {
        Graphics g = e.ChartGraphics.Graphics;
        ChartArea ca = chart1.ChartAreas[0];
        Series s0 = chart1.Series[0];
        List<PointF> points = new List<PointF>();
        for (int i = 0; i < s0.Points.Count; i++)
            points.Add(RadarValueToPixelPosition(s0, i, chart, ca));
        g.FillPolygon(Brushes.LightSalmon, points.ToArray());
    }
