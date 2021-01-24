    private void chart1_PostPaint(object sender, ChartPaintEventArgs e)
    {
        Axis ay = chart1.ChartAreas[0].AxisY;
        Axis ax = chart1.ChartAreas[0].AxisX;
        int x0 = (int) ax.ValueToPixelPosition(ax.Minimum);
        int x1 = (int) ax.ValueToPixelPosition(ax.Maximum);
        double totalDist = 0;
        foreach (var ts in TrainStops)
        {
            int y = (int)ay.ValueToPixelPosition(totalDist);
            totalDist += ts.Item2;
            using (Pen p = new Pen(ts.Item3 == 1 ? Color.DarkGray : Color.Black, 
                                   ts.Item3 == 1 ? 0.5f : 1f))
                e.ChartGraphics.Graphics.DrawLine(p, x0 + 1, y, x1, y);
        }
        // ** Insert marker drawing code (from update below) here !
    }
