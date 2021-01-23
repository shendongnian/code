    var data = new MeasureData[]
    {
        new MeasureData
        {
            Id = 10,
            Description = "Air Temperature #1",
            AverageData = "1 Minute Run Average",
            Unit = "Celsius",
            Minutes = "Minute 59-60"
        },
        new MeasureData
        {
            Id = 11,
            Description = "Humidity",
            AverageData = "1 Minute Run Average",
            Unit = "%",
            Minutes = "Minute 59-60"
        }
        // and so on
    };
    myDataGridView.DataSource = data;
