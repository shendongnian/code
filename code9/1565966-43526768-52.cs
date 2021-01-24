    for (int i = 1; i < chart.Series.Count; i++)
    {
        DataPoint dp = new DataPoint();
        S1.Points.Add(dp);
        dp["BoxPlotSeries"] =  "D" + i;  // names D1-D6
        dp.Color = chart.Series[i].Color;
    }
