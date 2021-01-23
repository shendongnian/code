    using(var context = new MyDbContext())
    {
        // Get the table. This can serve as your repository.
        DbSet<Customer> table = context.Customers;
        
        // If you're using generics you can do like this as well.
        DbSet<Customer> otherTable = context.Set<Customer>();
        // Specify your explicit query.
        IQueryable<Customer> query = table.Where(x => x.Name == 'Jenny');
        
        // Note that EF still haven't executed a query.
        // By calling methods like ToList() or FirstOrDefault() it will run the query.
        IList<Customer> result = query.ToList();
    }
