    private void chart_PostPaint(object sender, ChartPaintEventArgs e)
    {
        Graphics g = e.ChartGraphics.Graphics;
        Axis ax = chart.ChartAreas[0].AxisX;
        Axis ay = chart.ChartAreas[0].AxisY;
      
        for (int si = 0; si < chart.Series.Count; si++ )
        {
            Series s = chart.Series[si];
            for (int pi = 1; pi < s.Points.Count - 1; pi++)
            {
                DataPoint dp = s.Points[pi];
                int y = (int) ay.ValueToPixelPosition(dp.YValues[0]+1);       ///*1*
                int x1 = (int)ax.ValueToPixelPosition(s.Points[pi-1].XValue); ///*2*
                int x2 = (int)ax.ValueToPixelPosition(dp.XValue);
                using (Pen pen = new Pen(dp.Color, 40)                        ///*3*
                { StartCap = System.Drawing.Drawing2D.LineCap.Flat,
                    EndCap = System.Drawing.Drawing2D.LineCap.Flat })
                {
                    g.DrawLine(pen, x1, y, x2, y);
                }
            }
        }
