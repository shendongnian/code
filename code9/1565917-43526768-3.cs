    for (int i = 0; i < 6; i++)
    {
        Series sx = chart.Series.Add("D" + (i+1));
        sx.ChartType = SeriesChartType.Line;
        sx.Points.DataBindY(yyValues.Select(x => x[i]).ToArray());
    }
