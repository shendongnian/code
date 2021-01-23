    List<filteredEntry> filteredGroupEntry = groupEntry
      .GroupBy(entry => new { // grouping by name + age
         name = entry.name,
         age = entry.age})
      .Select(chunk => new filteredEntry() { 
         name = chunk.Key.name,
         age = chunk.Key.age, 
         // collapse all likes into list
         likes = chunk.Select(entry => entry.likes).ToList()})
      .ToList();
