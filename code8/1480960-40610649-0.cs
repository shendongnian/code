    var series = new Series { 
                     Name = "S2", 
                     Color = Color.LightSlateGray, 
                     ChartType = SeriesChartType.Rangebar
    };
    series["PointWidth"] = "5";
    
    chart1.Series.Add(series);
