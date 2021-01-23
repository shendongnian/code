    var results = dt.AsEnumerable()
                    .GroupBy(dr => dr.Field<string>("Affiliate Name"))
                    .Select((group, dr) => new 
                    {
                        AffiliateName = group.Key,
                       CallsCount = group.Sum(dr.Field<int>("Call")))
                    });
    foreach(var result in results)
    {
        // Use results
        Console.WriteLine($"{result.AffiliateName}: {result.CallsCount}");
    }
