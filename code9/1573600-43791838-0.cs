    public MyController(IConfiguration configuration, AContext aContext, BContext bContext)
        : base(aContext)
    { 
        _aContext = aContext;
        _bContext = bContext;
    }
    public Task<IActionResult> GetSomething(int id)
    {
        var customerTask = await aContext.Customers
                                         .FirstOrDefaultAsync(customer => customer.Id == id);
        var sellerTask = await aContext.Sellers
                                       .FirstOrDefaultAsync(seller => seller.CustomerId == id);
        var ordersTask = await bContext.Orders
                                       .Where(order => order.CustomerId == id)
                                       .ToListAsync();
        var invoicesTask = await bContext.Invoices
                                         .Where(invoice => invoice.CustomerId == id)
                                         .ToListAsync();
        var allTasks = new[] { customerTask, sellerTask, ordersTask, invoicesTask};
        await Task.WhenAll(allTasks);
        // Do staff with result of completed tasks
        Return OK(calculatedResult);
    }
