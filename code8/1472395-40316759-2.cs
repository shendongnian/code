    ToolTip tt = null;
    Point tl = Point.Empty;
    private void chart1_MouseMove(object sender, MouseEventArgs e)
    {
        if (tt == null )  tt = new ToolTip();
        ChartArea ca = chart1.ChartAreas[0];
        double x = ca.AxisX.PixelPositionToValue(e.X);
        double y = ca.AxisY.PixelPositionToValue(e.Y);
        if (e.Location != tl)
            tt.SetToolTip(chart1, string.Format("X={0:0.00} ; {1:0.00}", x, y ));
        tl = e.Location;
    }
