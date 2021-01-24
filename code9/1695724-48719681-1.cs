    private void chart1_PostPaint(object sender, ChartPaintEventArgs e)
    {
        Axis ax = chart1.ChartAreas[0].AxisX;
        Axis ay = chart1.ChartAreas[0].AxisY;
        foreach (DateTime d in markers)
        {
            int x = (int)ax.ValueToPixelPosition(d.ToOADate());
            int y0 = (int)ay.ValueToPixelPosition(ay.Minimum);
            int y1 = (int)ay.ValueToPixelPosition(ay.Maximum);
            e.ChartGraphics.Graphics.DrawLine(Pens.Red, x, y0, x, y1);
        }
    }
