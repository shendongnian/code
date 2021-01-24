            chartStats.Series.Clear();
            var series1 = new Series
            {
                Name = "Series1",
                Color = System.Drawing.Color.Green,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.DateTime
            };
            chartStats.Series.Add(series1);
            foreach(var result in Data.List)
            {
                series1.Points.AddXY(result.Date, result.Errors);
            }
            chartStats.Invalidate();
