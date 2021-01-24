        CartesianChart ch = new CartesianChart();
        ch.Series = new SeriesCollection
        {
            new LineSeries
            {
                Title = "Series 1",
                Values = new ChartValues<double> { 1, 1, 2, 3 ,5 }
            }
        };
        TestGrid.Children.Add(ch);
