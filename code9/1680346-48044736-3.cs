    var customerFromDb = customers
        .Find(p => p.CustomerId == customer.CustomerId)
        .Single();
    
    if (!string.IsNullOrWhiteSpace(customer.City))
        customerFromDb.City = customer.City;
    if (!string.IsNullOrWhiteSpace(customer.Name))
        customerFromDb.Name = customer.Name;
    if (!string.IsNullOrWhiteSpace(customer.Family))
        customerFromDb.Family = customer.Family;
    if (!string.IsNullOrWhiteSpace(customer.Sex))
        customerFromDb.Sex = customer.Sex;
    
    customers.ReplaceOne(p => p.CustomerId == customer.CustomerId, customerFromDb);
