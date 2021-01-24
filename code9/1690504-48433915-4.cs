    var summary = orders.Where(x => x.OrderLines != null) // Check for null as there seems to be null orderlines in your model
                        .SelectMany(x => x.OrderLines)  // Flatten
                        .GroupBy(x => x.itemName)       // Group
                        .Select(group => new            // Project
                                  {
                                     ItemName = group.Key,
                                     TotalQuantity = group.Sum(x => x.quantity)
                                  })
                        .ToList();                      // To List
