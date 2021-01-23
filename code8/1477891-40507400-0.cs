    private void chart2_MouseMove(object sender, MouseEventArgs e)
    {
        Axis ax = chart1.ChartAreas[0].AxisX;
        Axis ay = chart1.ChartAreas[0].AxisY;
        if (e.Button.HasFlag(MouseButtons.Left))  // only draw when the button is pressed
        {
            // convert pixels to values!
            chart1.Series[0].Points.AddXY(ax.PixelPositionToValue(e.X), 
                                            ay.PixelPositionToValue(e.Y));
            if (chart1.Series[0].Points.Count > 200)
            {
                chart1.Series[0].Points.RemoveAt(0);
            }
        }
