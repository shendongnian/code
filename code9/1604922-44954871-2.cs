    var groupedByUsername = itemTransactions
        .GroupBy(_ => _.Username)
        .Select(group => new MyClass
        {
            TotalItems = items.Count(_ => _.Username == group.Key),
            SuccessfulItems = group.Count()
        })
        .ToList();
