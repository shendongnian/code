    private static Expression<Func<FooTable, IOrderedQueryable<FooTable>>> GetOrderByExpression(DBEntities dbContext, bool isDesending)
    {
        if (isDesending)
        {
            return x => dbContext.FooTables.OrderByDescending(y => y.Date);
        }
        else
        {
            return x => dbContext.FooTables.OrderBy(y => y.Date);
        }
    }
