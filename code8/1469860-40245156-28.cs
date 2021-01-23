    private void chart1_PostPaint(object sender, ChartPaintEventArgs e)
    {
        if (chart3D.Series.Count < 1) return;
        if (chart3D.Series[0].Points.Count < 1) return;
        Chart chart = sender as Chart;
        ChartArea ca = chart .ChartAreas[0];
        e.ChartGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        List<List<PointF>> data = new List<List<PointF>>();
        foreach (Series s in chart .Series)
            data.Add(GetPointsFrom3D(ca, s, s.Points.ToList(), e.ChartGraphics));
        renderLines(data, e.ChartGraphics.Graphics, chart , true);  // pick one!
        renderPoints(data, e.ChartGraphics.Graphics, chart , 6);   // pick one!
    }
