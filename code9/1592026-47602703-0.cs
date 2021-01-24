    static void EFTest()
    {
        using (var dbContext = new DBEntities())
        {
            // debug - print query
            dbContext.Database.Log = Console.WriteLine;
            // get order by expression
            var orderByExpression = GetOrderByExpression(dbContext, true);
            // execute query
            var result = dbContext.FooTables
                                  .AsExpandable()
                                  .SelectMany(x => orderByExpression.Invoke(x))
                                  .ToList();
        }
    }
