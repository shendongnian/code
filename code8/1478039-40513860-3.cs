    private void chart1_PrePaint(object sender, ChartPaintEventArgs e)
    {
        using (Pen pen = new Pen(Color.Green, 2f))
            e.ChartGraphics.Graphics.DrawLine(pen,
                PointFromDataPoint(chart1, chart1.ChartAreas[0], pontoantigo),
                PointFromDataPoint(chart1, chart1.ChartAreas[0], pontoatual));
    }
