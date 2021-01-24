    TimeSpan interval = new TimeSpan(0, 43, 0);
    DateTime anchor = new DateTime(2018, 1, 5, 7, 0, 49);
    
    var iterations = DateTime.Now.Subtract(anchor).Ticks / interval.Ticks;
    
    DateTime current = anchor;
    
    for(var i = 0; i < iterations; i++)
        current = current.AddTicks(interval.Ticks);
    
    var untilNext = DateTime.Now.Subtract(current);
    
    Console.Write(untilNext);
