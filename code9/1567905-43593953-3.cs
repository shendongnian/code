    var groupCount = studyGroup
    .Where(group => 
           categoryHashset.All(c => group.Category.Contains("|" + c + "|") 
                                    ||
                                    group.Category.StartsWith(c + "|")
                                    ||
                                    group.Category.EndsWith("|" + c)
                                    ||
                                    group.Category.Equals(c))
    .GroupBy(s => s.ID)
    .Select(g => new { ID = g.Key, Count = g.Count() });
