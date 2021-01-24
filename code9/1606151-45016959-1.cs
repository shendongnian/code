    Dictionary<string, List<Rectangle>> ChartColumnRectangles = null;
    Dictionary<string, List<Rectangle>> GetChartColumnRectangles(Chart chart, ChartArea ca)
    {
        Dictionary<string, List<Rectangle>> allrex = new Dictionary<string, List<Rectangle>>();
        foreach (var s in chart.Series)
        {
            allrex.Add(s.Name, GetColumnSeriesRectangles(s, chart, ca));
        }
        return allrex;
    }
