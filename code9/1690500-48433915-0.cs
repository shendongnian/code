    var summary = orders.SelectMany(x => x.OrderLines) // Flatten
                        .GroupBy(x => x.itemName)      // Group
                        .Select(group => new           // Project
                                  {
                                     Metric = group.Key,
                                     Count = group.Count()
                                  })
                        .ToList();                     // To List
