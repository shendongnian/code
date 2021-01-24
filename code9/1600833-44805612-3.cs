    private void chart_MouseDown(object sender, MouseEventArgs e)
    {
        Axis ay = chart.ChartAreas[0].AxisY;
        Axis ax = chart.ChartAreas[0].AxisX;
        //store previous data
        if (e.Button == MouseButtons.Left)
        {
            mDown = e.Location;
            prevXMax = ax.Maximum;
            prevXMin = ax.Minimum;
            prevYMax = ay.Maximum;
            prevYMin = ay.Minimum;
        }
    }
