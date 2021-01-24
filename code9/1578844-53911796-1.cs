    public ChartValues<DateTimePoint> RawDataSeries
    {
        get
        {
            ChartValues<DateTimePoint> Values = new ChartValues<DateTimePoint>();
            foreach (DatabaseEntry dbe in _Readings)
            {
                Values.Add(new DateTimePoint(dbe.Timestamp, dbe.Value));
            }
            return Values;
        }
    }
