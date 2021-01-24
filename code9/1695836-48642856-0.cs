    var pairs = Logs.SelectMany(x => x.IndexPattern.Split(',').Select(y => new { 
    Index = y, Type= x.Type }));
    var pairs2 = (from p in pairs group p by p into grp select new { Index = 
    grp.Key.Index, Reason = grp.Key.Type, Count = grp.Count() }
                ).OrderByDescending(p => p.Count);
    foreach (var i  in pairs2) 
    {
       //print with i
    }
