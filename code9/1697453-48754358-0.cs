    var customerIds = dc.Contact
    .Where(c => (c.FirstName + " " + c.LastName).Contains(text))
                          .Select(c => c.CustomerId)
    .Distinct()
    .ToArray();
    
    var customers = dc.Customer
    .Where(c => customerIds.Contains(c.Id))
    .ToArray();
                  
