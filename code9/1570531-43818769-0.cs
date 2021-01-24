    //this context writes SQL to any logs and to ReSharper test output window
    using (var context = new TestContext(_loggerFactory))
    {
        var customers = context.Customer.ToList();
    }
    //this context doesn't
    using (var context = new TestContext())
    {
        var products = context.Product.ToList();
    }
