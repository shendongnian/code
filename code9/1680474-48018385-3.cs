    using(var ctx = new AuthorizationContext())
    {
        ctx.Filter<Orders>(q => q.Where(x => x.Price <= 5000));
    
        var orders = ctx.Orders.ToList();//where x.Price <= 5000 is applied implicitly
    }
