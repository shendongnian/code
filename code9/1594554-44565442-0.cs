    var stopData = stops 
       .Where(stop => stop.InitDate != null)
       .SelectMany(stop => new
       { 
           GroupKey = new 
           {
               Month = stop.InitDate.Month,
               Year = stop.InitDate.Year,
           },
           Duration = stop.Duration
       });
