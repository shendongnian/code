    private double prevMax = 0;
    private double prevMin = 0;
    private Point mDown = Point.Empty;
    private void chart_MouseDown(object sender, MouseEventArgs e)
    {
        Axis ax = chart.ChartAreas[0].AxisX;
        //store initial data
        if (e.Button == MouseButtons.Left)
        {
            mDown = e.Location;
            prevMax = ax.Maximum;
            prevMin = ax.Minimum;
        }
    }
    private void chart_MouseMove(object sender, MouseEventArgs e)
    {
        Axis ax = chart.ChartAreas[0].AxisX;
        //if mouse was moved and mouse left click
        if (e.Button == MouseButtons.Left)
        {
            double x0 = ax.PixelPositionToValue(mDown.X);
            double x1 = ax.PixelPositionToValue(e.X);
            ax.Minimum = prevMin - (x1 - x0);
            ax.Maximum = prevMax - (x1 - x0);
         }
    }
