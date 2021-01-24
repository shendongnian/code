    var summary = orders.Where(x => OrderLines != null) // Check for null as there seems to be null orderlines in your model
                        .SelectMany(x => x.OrderLines)  // Flatten
                        .GroupBy(x => x.itemName)       // Group
                        .Select(group => new            // Project
                                  {
                                     Metric = group.Key,
                                     Count = group.Count()
                                  })
                        .ToList();                      // To List
