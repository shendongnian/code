    private void chart_MouseDown(object sender, MouseEventArgs e)
    {
        //store previous data
        if (e.Button == MouseButtons.Left)
        {
            mDown = e.Location;
            prevXMax = chart.ChartAreas[0].AxisX.Maximum;
            prevXMin = chart.ChartAreas[0].AxisX.Minimum;
            prevYMax = chart.ChartAreas[0].AxisY.Maximum;
            prevYMin = chart.ChartAreas[0].AxisY.Minimum;
        }
    }
