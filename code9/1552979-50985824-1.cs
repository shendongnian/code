    var series = new LineSeries
    {
        Color = OxyColors.SeaShell,
        LineStyle = LineStyle.Dash
    };
    foreach (DataPoint p in ListOfPoints)
    {
        series.Points.Add(p);
    }
    plotModel.Series.Add(series);
    plotModel.InvalidatePlot(true);
