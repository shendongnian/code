    var filter = Builders<Customer>.Filter
        .Eq(s => s.CustomerId, customer.CustomerId); //perhaps requires an index on CustomerId field
    var update = Builders<Customer>.Update
        .Set(p => p.CustomerId, customer.CustomerId);
    if (!string.IsNullOrWhiteSpace(customer.City))
        update = update.Set(p => p.City, customer.City);
    if (!string.IsNullOrWhiteSpace(customer.Name))
        update = update.Set(p => p.Name, customer.Name);
    if (!string.IsNullOrWhiteSpace(customer.Family))
        update = update.Set(p => p.Family, customer.Family);
    if (!string.IsNullOrWhiteSpace(customer.Sex))
        update = update.Set(p => p.Sex, customer.Sex);
    
    customers.UpdateOne(filter, update);
