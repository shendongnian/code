    var sessionData = GetSessionData();
    var longestSession = sessionData
        .GroupBy(sd => sd.Session)
        .Select(group => new Tuple<Guid, TimeSpan>(group.First().Session, group.Max(sd => sd.Date) - group.Min(sd => sd.Date)))
        .OrderBy(tuple => tuple.Item2)
        .Last()
        .Item1;
    var averageDuration = sessionData
        .GroupBy(sd => sd.Session)
        .Select(group => new Tuple<Guid, TimeSpan>(group.First().Session, group.Max(sd => sd.Date) - group.Min(sd => sd.Date)))
        .Average(tuple => tuple.Item2.Minutes);
