    using (var dbContext = new CustomerDbContext(connectionString))
    {
        return dbContext.Customers.Include(customer => customer.PrimaryAddress).ToList();
    }
   
