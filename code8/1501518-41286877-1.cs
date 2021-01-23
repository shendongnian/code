    var LineGraph = _groupedItems.Union(Enumerable.Range(0, date_range)
              .Select(offset => new GroupedItem { _Date = DateTime.Now.AddDays(-(date_range)).AddDays(offset), Sales = 0} ))
                          .GroupBy(l => l._Date.Date)
                          .Select(cl => new GroupedItem
                          {
                               _Date = cl.Key,
                               Sales = cl.Sum(c=>c.Sales)
                          })
                          .OrderBy(x => x._Date)
                          .Where(t => t._Date <= DateTime.Now &&
                          t._Date >= DateTime.Now.Subtract(TimeSpan.FromDays(date_range+1)))
                          .ToList()
