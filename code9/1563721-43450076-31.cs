    public void AddTrainStopSeries(Chart chart, DateTime start, int count, int speed)
    {
        Series s = chart.Series.Add(start.ToShortTimeString());
        s.ChartType = SeriesChartType.Line;
        s.Color = speed == 0 ? Color.Black : Color.Brown;
        s.MarkerStyle = MarkerStyle.Circle;
        s.MarkerSize = 4;
        double totalDist = 0;
        DateTime ct = start;
        for (int i = 0; i < count; i++)
        {
            var ts = TrainStops[i];
            ct = ct.AddMinutes(ts.Item2 * (speed == 0 ? 1 : 1.1d));
            DataPoint dp = new DataPoint( ct.ToOADate(), totalDist );
            totalDist += TrainStops[i].Item2;
            s.Points.Add(dp);
        }
    }
