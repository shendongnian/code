    using (var dbContext = new MyDbContext(...))
    {   // Introduce a Customer:
        Customer customerToAdd = GetCustomerData();
        var addedCustomer = dbContext.Customers.Add(customerToAdd);
        // Introduce an order for this Customer
        Order addedOrder = dbContext.Orders.Add(new Order()
        {
            // addedCustomer has no Id yet, we can't use addedCustomer.Id
            Order.Customer = addedCustomer;
            ...
        });
        dbContext.SaveChanges();
    }
