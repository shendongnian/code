Additionally to @Pikoh's answer, you can also convert any IEnumerable to a ChartValues instance, using AsChartValues() extention:
    cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = yvals.AsChartValues(),
                },
            };
