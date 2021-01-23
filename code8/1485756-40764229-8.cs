    Dictionary<Customers, List<Orders>> dic = (from c in Customers
                                                          join o in Orders.OrderBy(o => o.DateTime).Take(10) on c.Id equals o.CustomerId into j1
                                                          from j2 in j1.DefaultIfEmpty()
                                                          group j2 by c into grouped
                                                          select new { Customers = grouped.Key, Orders = grouped.ToList() })
                                                         .ToDictionary(x => x.Customers, x => x.Orders);
