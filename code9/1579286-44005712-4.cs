     var invertedYMapper = LiveCharts.Configurations.Mappers.Xy<ObservablePoint>()
                .X(point => point.X)
                .Y(point => -point.Y);
            var lineSeries = new LineSeries
            {
                Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0,2),
                        new ObservablePoint(1,5),
                        new ObservablePoint(2,7)
                    }
            };
            // set the inverted mapping...
            lineSeries.Configuration = invertedYMapper;
            var seriesCollection = new SeriesCollection
            {
                lineSeries
            };
            // correct the labels
            var YAxis = new Axis
            {
                LabelFormatter = x => (x * -1).ToString()
            };
            cartesianChart1.AxisY.Add(YAxis);
            cartesianChart1.Series = seriesCollection;
