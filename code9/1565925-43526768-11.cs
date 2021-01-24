    for (int i = 0; i < 6; i++)
    {
        Series ds = chart.Series.Add("D" + (i+1));  // set a name D1, D2..
        dx.ChartType = SeriesChartType.Line;
        dx.Points.DataBindY(yyValues.Select(x => x[i]).ToArray());
    }
