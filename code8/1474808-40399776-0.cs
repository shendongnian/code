    var series = Enumerable.Range(1, item.SensorNumber)
        .Select(i => chart.Series.First(s => s.Name == ("dsSensor" + i)))
        .ToArray();
    for(var i = 0; i < series.Length; ++i){
        series[i].Enabled = true;
    }
