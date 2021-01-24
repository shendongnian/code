    public Customer LoadCustomerIncludingSalesOrders(int customerId) {
     var customer = Customers.
       .Include(c => c.SalesOrders)
       .Include(c => c.SalesOrders.Select(so => so.DeliveryAddress))
       .FirstOrDefault(c => c.Id == customerId);
      return customer;
    } 
