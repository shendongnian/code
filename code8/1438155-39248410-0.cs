    private void chart1_SelectionRangeChanged(object sender, CursorEventArgs e)
    {
        ranges.Add(curRange);
        selectedIndices.Union(collectDataPoints(chart1.Series[0], 
                              curRange.Width, curRange.Height))
                       .Distinct();
        StripLine sl = new StripLine();
        sl.BackColor = Color.FromArgb(255, Color.LightSeaGreen);
        sl.IntervalOffset = Math.Min(curRange.Width, curRange.Height);
        sl.StripWidth = Math.Abs(curRange.Height - curRange.Width);
        chart1.ChartAreas[0].AxisX.StripLines.Add(sl);
    }
