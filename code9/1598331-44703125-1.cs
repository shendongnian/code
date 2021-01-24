    foreach(ChartValue val in SavedChartValues)
    {
    ChartValues.Add(new MeasureModel
                    {
                        DateTime = val.Time,
                        Value = val.Value
                    });
    }
