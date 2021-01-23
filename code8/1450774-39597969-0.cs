    var existing = from m in master join s in subset on m.Id equals s.Id 
                   select new { Master = m, Subset = s };
    foreach (var both in existing)
    {
        both.Master.IsMatched = both.Subset.IsMatched;
    }
