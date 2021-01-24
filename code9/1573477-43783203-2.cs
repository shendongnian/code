    var propNames = new[] {"prop1", "prop2", "prop3"};
    var firstPositive = propNames
        .Select(name => new {
            Name = name
        ,   TotalReturn = MakeApiCall(name)
        }).FirstOrDefault(res => res.TotalReturn > 0);
    if (firstPositive != null) {
        Console.WriteLine("TotalReturn for {0} was {1}", firstPositive.Name, firstPositive.TotalReturn);
    } else {
        Console.WriteLine("No positive TotalReturn");
    }
