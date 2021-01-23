    ToolTip tt = null;
    Point tl = Point.Empty;
    private void chart1_MouseMove(object sender, MouseEventArgs e)
    {
        if (tt == null )  tt = new ToolTip();
        ChartArea ca = chart1.ChartAreas[0];
        Axis ax = ca.AxisX;
        Axis ay = ca.AxisY;
        double x = ax.PixelPositionToValue(e.X);
        double y = ax.PixelPositionToValue(e.Y);
        if (e.Location != tl)
            tt.SetToolTip(chart1, string.Format("X={0:0.00} ; {1:0.00}", x, y ));
        tl = e.Location;
    }
