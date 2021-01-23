    var duplicates = list.GroupBy(x => x) // or x.Property if you are grouping by some property.
                         .Where(g => g.Count() > 1)
                         .SelectMany(g => g);
    var uniques = list.GroupBy(x => x) // or x.Property if you are grouping by some property.
                      .Where(g => g.Count() == 1)
                      .SelectMany(g => g);
