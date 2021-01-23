    Func<ChartPoint, string> labelPoint = chartPoint =>
            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            ChartValues<double> cht_y_values = new ChartValues<double>();
   
            LiveCharts.SeriesCollection series = new LiveCharts.SeriesCollection();
            foreach (DataRow dr in dt.Rows)
            {
                PieSeries ps = new PieSeries
                {
                    Title = dr[x_column_name].ToString(),
                    Values = new ChartValues<double> {
                                    double.Parse(dr[y1_column_name].ToString())},
                    DataLabels = true,
                    LabelPoint = labelPoint
                };
                series.Add(ps);
            }
       pieChart.Series = series;
