    using (var transaction = modelContext.BeginTransaction())
    {
        var maxOrderNumber = modelContext.Orders.Max(o => o.OrderNumber);
        var newOrder = new Order { OrderNumber = maxOrderNumber };
        ...
        transaction.Commit();
    }
