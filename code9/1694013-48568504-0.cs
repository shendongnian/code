    Expression<Func<Customer,long>> func = c => c.Orders
      .Where(order => order.OrderDate >= DateTime.Now.AddDays(-30)
      .Sum(order => order.TotalValue);
    var result = await ctx.Customers
      .AsExpandable() // this allow to unwrap injected expression
      .Select(cust => new CustomerDto {
        CustomerId = cust.Id,
        CustomerName = cust.Name,
        CurrentValue = func.Invoke(cust) // this inject predefined expression
      })
      .ToListAsync(); 
   
