    void AddFlagLine(Chart chart, int series, int flag, int x)
    {
        Series s = chart.Series[series];
        int px = s.Points.AddXY(x, series);
        s.Points[px].Color = s.Color;
        if (px > 0) s.Points[px - 1].Color = flag == 1 ? s.Color : Color.Transparent;
    }
