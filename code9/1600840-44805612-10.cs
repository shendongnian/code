    private void chart_MouseMove(object sender, MouseEventArgs e)
    {
        Axis ax = chart.ChartAreas[0].AxisX;
        Axis ay = chart.ChartAreas[0].AxisY;
        //if mouse was moved and mouse left click
        if (e.Button == MouseButtons.Left)
        {
            double x0 = ax.PixelPositionToValue(mDown.X);
            double x1 = ax.PixelPositionToValue(e.X);
            double y0 = ay.PixelPositionToValue(mDown.Y);
            double y1 = ay.PixelPositionToValue(e.Y);
            ax.Minimum = prevXMin + (x0 - x1);
            ax.Maximum = prevXMax + (x0 - x1);
            ay.Minimum = prevYMin + (y0 - y1);
            ay.Maximum = prevYMax + (y0 - y1);
        }
    }
