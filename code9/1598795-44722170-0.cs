    var result = data.GroupBy(x => new {x.ClientID, x.ItemID})
                .Select(
                    g =>
                        new
                        {
                            g.Key.ClientID,
                            g.Key.ItemID,
                            AvgPrice = g.Average(c => c.Price), 
                            SumQuantity = g.Sum(c => c.Quantity)
                        });
