    var totalPerMonth = data.AsEnumerable()
        .Select(x => new {
           Date = Convert.ToDateTime(x.ItemArray[0]).ToString("yyyy-MM"),
           Country = x.ItemArray[1],
           Revenue = Convert.ToDouble(x.ItemArray[2]) // convert here
         })
        .GroupBy(x => x.Country)
        .ToDictionary(
           g => g.Key,
           g => g.GroupBy(x => x.Date).ToDictionary(dg => dg.Key, dg => dg.Sum(x => x.Revenue))
        ); 
