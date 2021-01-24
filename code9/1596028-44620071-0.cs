    ...
    List<TimeEvent> TimeEvents;
    public TimeSeries(List<TimeEvent> timeEvents)
    {
        TimeEvents = timeEvents;
    }
    
    public IEnumerable<DateTime> Time
    {
        get
        {
            foreach (var item in TimeEvents)
            {
                yield return item.Time;
            }
        }
    }
    
    public IEnumerable<double> Values
    {
        get
        {
            foreach (var item in TimeEvents)
            {
                yield return item.Value;
            }
        }
    }
