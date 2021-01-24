    var periods = new List<Period>();
    var period = new Period { Begin = new DateTime(2017, 07, 01, 7, 50, 0), End = new DateTime(2017, 07, 01, 12, 30, 0) };        
    var previous = period.Begin;
    
    do
    {
        var next = new Period { End = previous.AddMinutes(60 - previous.Minute - 1).AddSeconds(59), Begin = previous };
        previous = next.End.AddMinutes(1);
        if (next.End < period.End)
            periods.Add(next);
        else
        {
            next.End = period.End.AddMinutes(-1).AddSeconds(59);
            periods.Add(next);
            break;
        }                
    } while (true);
