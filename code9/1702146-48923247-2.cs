    var result = myCustomers.Select(customer => new
    {
        CustomerId = customer.Id,
        AnalysisCodes = customer.ExtractProperties(allCustomerProperties)
            .ToList();
    }
