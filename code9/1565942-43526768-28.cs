    for (int i = 0; i < 3; i++)
    {
        Series bps = chart.Series.Add("BoxPlotSeries" + i);
        bps.ChartType = SeriesChartType.BoxPlot;
        var yValOne = yValues.Select(x => new[] { x[i] }).ToArray();
        bps.Points.DataBindY(yValOne);
    }
