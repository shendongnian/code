    var Query1 = from o in Orders
                 group o by o.CustomerId into grp
                 select new {
                     CustomerId = grp.Key,
                     OrderCount = grp.Count(),
                     OrderCounts = from g in grp
                                   group g by g.OrderType into grp2
                                   select new { OrderType = grp2.Key, Count = grp2.Count() }
                 };
