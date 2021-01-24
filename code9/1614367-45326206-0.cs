    Period period = new Period();
    period.Begin = new DateTime(2017, 7,1, 7,50,0);
    period.End = new DateTime(2017, 7, 1, 12, 30, 0);
    	
    DateTime start = period.Begin;
    	
    List<Period> periods = new List<Period>();
    while(start < period.End)
    {
       DateTime end = start;
       end = end.AddMinutes(-end.Minute);
       end = end.AddSeconds(-1);
       end = end.AddHours(1);
       if(end > period.End)
          end = period.End;
    
       periods.Add(new Period{Begin = start, End = end});
       start = end.AddSeconds(1);
    }
    	
    foreach(var p in periods)
    {
       Console.WriteLine($"Start: {p.Begin.ToLongTimeString()} End: 
       {p.End.ToLongTimeString()}");
    }
