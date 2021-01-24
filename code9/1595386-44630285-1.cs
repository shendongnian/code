    query.ToLookup(item => item.Name, s=> s.BeveragesList);
    // or if you're confident there are no duplicates
    query.ToDictionary(item => item.Name, s=> s.BeveragesList);
    // to flatten the list project your results using:
    query.ToLookup(item => item.Name, s=> s.BeveragesList)
      .Select(s=> new { 
                          Name = s.Key, 
                          BeveragesList = s.SelectMany(t => t).ToArray()
                       })
      .ToArray()
    // instead of
    query.ToList(...);
    
