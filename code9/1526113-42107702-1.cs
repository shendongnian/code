    int MarkerSize(Chart chart, int count)
    {
        return chart.ClientSize.Width / count + 1;
    }
    void Rescale(Chart chart)
    {
        Series s = chart3.Series[0];
        s.MarkerSize = MarkerSize(chart3, (int)Math.Sqrt(s.Points.Count));
    }
