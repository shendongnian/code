    var amounts = new[]
    {
       new 
       {
           Amount = 100.00m,
           Name = "ABC",
           Id = 101,
       },
       new
       {
           Amount = -100.00m,
           Name = "ABC",
           Id = 101,
       },
       new
       {
           Amount = 50.00m,
           Name = "XYZ",
           Id = 123,
       },
       new
       {
           Amount = -100.00m,
           Name = "XYZ",
           Id = 123,
       },
    };
    
    // summarise everything
    var summaries = from a in amounts
                    group a by new { a.Id, a.Name } into grouping
                    select new
                    {
                        Amount = grouping.Sum(g => g.Amount),
                        grouping.Key.Name,
                        grouping.Key.Id,                    
                    };
        
    // get the ids of records we need the full audit log for
    var zeroSummaries = summaries.Where(s => s.Amount == 0).Select(s => s.Id).ToList();
    // concat the summarised records together with the ones we need the full audit log for
    summaries = amounts.Where(a => zeroSummaries.Contains(a.Id))
                       .Concat(summaries.Where(s => s.Amount != 0));
