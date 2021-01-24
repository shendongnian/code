    // Now its safe to add new prices;
    foreach (var item in priceList)
    {
        item.ApimappingId = null;
        context.Employees.Add(item);
    }
    context.SaveChanges();
