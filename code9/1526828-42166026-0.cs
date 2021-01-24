        var values = weeklySatisfaction.Select(o => new 
       { 
         Week = o.Week, 
         Net = weeklySatisfaction
                     .Where(i => i.Week < o.Week)
                     .Select(x => x.Positive - x.Negative).Sum() 
       });
