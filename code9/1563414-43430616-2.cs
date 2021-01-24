    var result = from r in db.Orders
                 group r by r.OrderDate.Month
                 into g
                 select new YearlySalesDto { 
                    Month = g.Key.ToString(), // The  ?? "" is unnecessary. 
                    TotalSales = g.Sum(p => p.OrderItems.Select(x => x.Quantity * x.UnitPrice).Sum()) 
                };
    var fixedResult = result.AsEnumerable()
                            .Union(Enumerable.Range(1,12)
                                             .Select(x=>new YearlySalesDto { Month = x.ToString(), TotalSales = 0 })
                                   , new MonthComparer());
    //Elsewhere
    class MonthComparer : IEqualityComparer<YearlySalesDto>
    {
        public bool Equals(YearlySalesDto x, YearlySalesDto y)
        {
            return x.Month == y.Month;
        }
        public int GetHashCode(YearlySalesDto x)
        {
            return x.Month.GetHashCode();
        }
    }
