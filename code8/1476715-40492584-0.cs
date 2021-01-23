    private void chart1_MouseMove(object sender, MouseEventArgs e)
    {
        ChartArea ca = chart1.ChartAreas[0];
        Series S = chart1.Series[0];
        RectangleF rf = InnerPlotPositionClientRectangle(chart1, ca);
        float px = (float)( (e.X - rf.X) * S.Points.Count / rf.Width );
        int p0 = (int)px;  // previous point
        int p1 = p0 + 1;   // next point
        if (p0 >= 0 &&  p0 < S.Points.Count)
            Console.WriteLine( "DataPoint # " + p0 + " has a y-value of " + 
                               S.Points[p0].YValues[0].ToString("0.00"));
        //..
    }
