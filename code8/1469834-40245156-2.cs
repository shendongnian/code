    private void chart3D_PostPaint(object sender, ChartPaintEventArgs e)
    {
        if (chart3D.Series.Count < 1) return;
        if (chart3D.Series[0].Points.Count < 1) return;
        //syncLabels();
        ChartArea ca = chart3D.ChartAreas[0];
        e.ChartGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        List<List<PointF>> data = new List<List<PointF>>();
        foreach (Series s in chart3D.Series)
            data.Add(GetPointsFrom3D(ca, s, s.Points.ToList(), e.ChartGraphics));
        renderLines(data, e.ChartGraphics.Graphics, chart3D, true);  // pick one!
        renderPoints(data, e.ChartGraphics.Graphics, chart3D, 6);   // pick one!
    }
