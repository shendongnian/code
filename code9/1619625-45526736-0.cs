    var result = dbContext.Customers
        .Where(c => c.Name == "Mostafa")
        .AsEnumerable()
        .Where(c => c.Age == 18)
        .ToList();
