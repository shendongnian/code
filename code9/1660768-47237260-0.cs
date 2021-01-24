            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisY.Add(
            new Axis
            {
                MinValue = 0 
            });
            cartesianChart1.Series.Add(
            new LineSeries
            {
                Title = "Series 1",
                Values = model.ImageGraphData().AsChartValues(),
                LineSmoothness = 0, //straight lines, 1 really smooth lines
                PointGeometry = null,
                PointGeometrySize = 0,
            });
