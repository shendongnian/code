    public static IEnumerable<DateTime> CreateIntervals(this DateTime start, TimeSpan interval)
    {
        while(true)
        {
            yield return start;
            start = start + interval;
        }
    }
    
    var timeList = startTime.CreateInterval(interval).Take(40).ToList();
