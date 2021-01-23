    var result = data.GroupBy(item => item.Date)
                     .Select(group => new { group.Key, Symbols = group.Select(item => item.Symbol).ToList() });
    //Or using a different overload of the `GroupBy`:
    var result = data.GroupBy(item => item.Date,
                              (key,group) => return new { Key = key, Symbols = group.Select(item => item.Symbol).ToList() });
    
