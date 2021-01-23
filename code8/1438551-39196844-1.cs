    var Query1 = from o in Orders
                 group o by new { o.CustomerId, o.OrderType } into grp
                 select new {
                     CustomerId = grp.Key.CustomerId,
                     OrderType = grp.Key.OrderType,
                     OrderCount = grp.Count()
                 };
