    var groupedByUsername = itemTransactions
        .GroupBy(_ => _.Username)
        .Select(group => new MyClass
        {
            TotalItems = items.Select(_ => _.ItemID).Distinct().Count(_ => _.Username == group.Key),
            SuccessfulItems = group.SelectMany(_ => _).Select(singleItem => singleItem.ItemID).Distinct().Count()
        })
        .ToList();
