    purchases.GroupBy(g => new { g.ClientId, g.ItemId })
             .Select(g => new
                          {
                               ClientId = g.Key.ClientId,
                               ItemId = g.Key.ItemId,
                               Price = g.Sum(p => p.Price * p.Quantity) / g.Sum(p => p.Quantity)
                            });
