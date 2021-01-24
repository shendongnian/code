    using (var mydbContext = new p4_databaseEntities())
    {
        LinqQueries linqQueries = new LinqQueries(myDbContext);
        // note that this constructor is very lightWeight!
        var result = linqQueries.MyQeury(...);
    }
