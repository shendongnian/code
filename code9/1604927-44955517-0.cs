    var itemsByUser = items
        .GroupBy(x => x.Username)
        .Select(x => new
        {
            Username = x.Key,
            Count = x.Count()
        };
    
    var itemsWithSalesByUser = itemTransactions
        .GroupBy(x => x.Username)
        .Select(x => new
        {
            Username = x.Key,
            Count = x.Count()
        };
    
    var joinedDataQuery =
        from i in itemsByUser 
        join s in itemsWithSalesByUser 
            on i.Username equals s.Username into sj
        from s in sj.DefaultIfEmpty() // left join
        select new MyClass
        {
             Username = i.Username
             TotalItems = i.Count,
             SuccessfulItems = s == null ? 0 : s.Count
        };
    
    var joinedData = joinedDataQuery.ToList();
