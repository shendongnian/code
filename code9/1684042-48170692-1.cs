    var context = new YourContext();
    var data = context.Set<T>()
        .AsQueryable()
        .Provider.CreateQuery(yourReceivedExpressionOfTEntity)
        .ToList();
