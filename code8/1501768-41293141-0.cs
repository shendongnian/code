    using LinqKit.Extensions;
    
    var orderDetails = context.Orders
        .AsExpandable()
        .Where(...)
        .Select(o => new { 
           Id = o.Id, 
           Date = o.Date, 
           PersonView = PersonView.Projector.Invoke(o.Person)
        })
        .FirstOrDefault();
