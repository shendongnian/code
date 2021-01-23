    using (var transaction = modelContext.BeginTransaction())
    {
        var newOrderNumber = modelContext.Orders.Max(o => o.OrderNumber) + 1;
        var newOrder = new Order { OrderNumber = newOrderNumber };
        ...
        transaction.Commit();
    }
