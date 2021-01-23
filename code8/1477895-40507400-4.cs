    private void timer1_Tick(object sender, EventArgs e)
    {
        Point cp = Control.MousePosition;
        chart1.Series[0].Points.AddXY(cp.X, -cp.Y);
        if (chart1.Series[0].Points.Count > 200)
        {
            chart1.Series[0].Points.RemoveAt(0);
        }
        chart1.ChartAreas[0].RecalculateAxesScale();   // <<-------
    }
