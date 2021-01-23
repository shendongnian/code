    var minDate = lineGraph.Min(g => g.Date.Date);
    var maxDate = lineGraph.Max(g => g.Date.Date);
    var range = GetDateRange(minDate, maxDate);
    
    var result = from date in range
                 from item in lineGraph.Where(g => g.Date.Date == date)
                                       .DefaultIfEmpty()
                 select new GroupedItem
                 {
                     Date = date,
                     Sales = item?.Sales ?? 0
                 };
