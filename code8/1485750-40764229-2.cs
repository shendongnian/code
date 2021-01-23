         Dictionary<Customers, List<Orders>> dic = dc.Customers.Join(dc.Orders,
                        c => c.Id,
                        o => o.CustomerId,
                        (c, o) => new { Customers = c, Orders = o }
                        )
                        .GroupBy(x => x.Customers)
                        .ToDictionary(x => x.Key, x => x.Select(y=>y.Orders)
                                                        .OrderBy(o => o.DateTime)
                                                        .Take(10)
                                                        .ToList());
