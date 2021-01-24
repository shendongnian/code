    Dictionary<DateTime, List<double>> dict = new Dictionary<DateTime, List<double>> {
    { DateTime.Now, new List<double> { 20, 25, 27, 30 } },                
    { DateTime.Now.AddDays(1), new List<double> { 20, 25, 27, 28 } },                
    { DateTime.Now.AddDays(2), new List<double> { 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 }
    }};
    
    var intersectedList = dict.Values.Skip(1)
        .Aggregate(
            new HashSet<double>(dict.Values.First()),
            (h, e) => { h.IntersectWith(e); return h; }
        );
