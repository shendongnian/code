    private void chart_PrePaint(object sender, ChartPaintEventArgs e)
    {
        ChartArea ca = chart.ChartAreas[0];
        Graphics g = e.ChartGraphics.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        // first get y top and bottom values:
        int y0 = (int)ca.AxisY.ValueToPixelPosition(ca.AxisY.Minimum);
        int y1 = (int)ca.AxisY.ValueToPixelPosition(ca.AxisY.Maximum);
        int iCount = 10;                         // number of gridlines per period
        var xes = new List<double>();            // the grid position values
        double xx = ca.AxisX.Minimum;
        do {
           xx *= ca.AxisX.LogarithmBase;         // next period
           double delta = 1d * xx / iCount ;     // distance in this period
           for (int i = 1; i < icount; i++) xes.Add(i * delta);  // collect the values
        }  while (xx < ca.AxisX.Maximum);
        // now we can draw..
        using (Pen pen = new Pen(Color.FromArgb(64, Color.Blue))
              {DashStyle = System.Drawing.Drawing2D.DashStyle.Dot} )
           foreach (var xv in xes)
           {
               float x = (float)ca.AxisX.ValueToPixelPosition(xv);
               g.DrawLine(pen, x, y0, x, y1);
           }
    }
