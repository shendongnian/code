    int rangeMin = -10; 
    int rangeMax = 20; 
    sDummy = chart.Series.Add("dummy");
    sDummy.Color = Color.Transparent;
    sDummy.IsVisibleInLegend = false;
    sDummy.ChartType = SeriesChartType.Point;
    sDummy.Points.AddXY(0, rangeMin + 1);
    sDummy.Points.AddXY(0, rangeMax - 1);
