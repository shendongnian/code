    var groupedByUsername = itemTransactions
        .GroupBy(_ => _.Username)
        .Select(group => new MyClass
        {
            TotalItems = items.Count(_ => _.Username == group.Key && !itemTransactions.Any(successfulTransaction.Id == _.Id)),
            SuccessfulItems = group.Count()
        })
        .ToList();
