    ToolTip tt = null;
    Point tl = Point.Empty;
    private void chart1_MouseMove(object sender, MouseEventArgs e)
    {
        if (tt == null )  tt = new ToolTip();
        ChartArea ca = chart1.ChartAreas[0];
        if (InnerPlotPositionClientRectangle(chart1, ca).Contains(e.Location))
        {
            Axis ax = ca.AxisX;
            Axis ay = ca.AxisY;
            double x = ax.PixelPositionToValue(e.X);
            double y = ay.PixelPositionToValue(e.Y);
            string s = DateTime.FromOADate(x).ToShortDateString();
            if (e.Location != tl)
                tt.SetToolTip(chart1, string.Format("X={0} ; {1:0.00}", s, y));
            tl = e.Location;
        }
        else tt.Hide(chart1);
    }
