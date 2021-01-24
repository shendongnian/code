    var highCountItems = source
      .GroupBy(item => item)
      .GroupBy(g => g.Count, g => g.Key)
      .OrderByDescending(counts => counts.Key)
      .First();
    
    int theCount = highCountItems.Key;
    var theItems = highCountItems.ToList();
