    public IQueryable<T> executeQuery<T>(T baseType, Expression<Func<T,bool>> whereFunc) where T : class 
    {
        //Get context
        DataContext dbContext = new DataContext(connection);
    
        //Get the table representation
        Table<T> baseTable = dbContext.GetTable<T>();
    
        //Get our query object
        IQueryable<T> baseQuery = baseTable.Where(whereFunc);
    }
