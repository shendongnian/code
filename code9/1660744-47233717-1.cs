    private void Button_Click(object sender, RoutedEventArgs e)
    {
		DataPlot = new PlotModel();
		DataPlot.Series.Add(new LineSeries());
        int steps = 60;
        IObservable<Coordinate> query =
            Observable
                .Generate(
                    0,
                    n => n < steps,
                    n => n + 1,
                    n => n * 2.0 * Math.PI / steps,
                    n => TimeSpan.FromMilliseconds(10.0))
                .Select(t => new Coordinate()
                {
                    X = (int)(Math.Cos(t) * 5000),
                    Y = (int)(Math.Sin(t) * 5000),
                });
        IDisposable subscription =
            query
                .ObserveOnDispatcher()
                .Subscribe(c =>
                {
                    (DataPlot.Series[0] as LineSeries).Points.Add(new DataPoint(c.X, c.Y));
                    DataPlot.InvalidatePlot(true);
                });
    }
