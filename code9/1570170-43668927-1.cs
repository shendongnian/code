    private void chart_PrePaint(object sender, ChartPaintEventArgs e)
    {
        ChartArea ca = chart.ChartAreas[0];
        Graphics g = e.ChartGraphics.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        // first get y top and bottom values:
        double aymin = ca.AxisY.Minimum;
        double aymax = ca.AxisY.Maximum;
        int y0 = (int)ca.AxisY.ValueToPixelPosition(aymin);
        int y1 = (int)ca.AxisY.ValueToPixelPosition(aymax);
        double axmin = ca.AxisX.Minimum;
        double axmax = ca.AxisX.Maximum;
        double lg = ca.AxisX.LogarithmBase;
        int icount = 10;  // number of gridlines per period
        var xes = new List<double>(); // the grid position values
        double xx = axmin;
        do {
           xx *= lg;                         // next period
           double delta = 1d * xx / icount;  // distance in this period
           for (int i = 1; i < icount; i++) xes.Add(i * delta);// collect the values
        }  while (xx < axmax);
        // now we can draw..
        using (Pen pen = new Pen(Color.FromArgb(64, Color.Blue))
              {DashStyle = System.Drawing.Drawing2D.DashStyle.Dot} )
           foreach (var xv in xes)
           {
               float x = (float)ca.AxisX.ValueToPixelPosition(xv);
               g.DrawLine(pen, x, y0, x, y1);
           }
    }
