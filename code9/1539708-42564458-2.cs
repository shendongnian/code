    private void chart1_MouseClick(object sender, MouseEventArgs e)
    {
        HitTestResult hit = chart1.HitTest(e.X, e.Y, ChartElementType.DataPoint);
        if (hit.PointIndex >= 0)
        {
            DataPoint dp = chart1.Series[0].Points[hit.PointIndex];
            label1.Text = "Value #" + hit.PointIndex + " = " + dp.XValue;
        }
    }
    private void chart1_MouseMove(object sender, MouseEventArgs e)
    {
        HitTestResult hit = chart1.HitTest(e.X, e.Y);
        var dp = hit.Object as DataPoint;
        Cursor = (dp is null) ? Cursors.Default : Cursors.Hand;
    }
