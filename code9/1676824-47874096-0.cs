    var records = logs
        .GroupBy(x => SqlFunctions.DatePart("dw", x.date))
        .Select(x =>
            new WeekCounts
            {
                Day = x.Key,
                Count = x.Count()
            }).ToList();
    
    for (int i = 0; i < 7; i++)
    {
        if (records.All(x => x.Day != i))
        {
            records.Add(new WeekCounts { Day = i, Count = 0 } );
        }
    }
    public class WeekCounts
    {
        public int? Day;
        public int Count;
    }
