    // using Z.EntityFramework.Plus; // Don't forget to include this.
    var ctx = new EntitiesContext();
    
    ctx.Filter<IUser>(q => q.Where(x => !x.IsSystemUser ));
    
    // SELECT * FROM Customers WHERE IsSystemUser = FALSE
    var list = ctx.Customers.ToList();
