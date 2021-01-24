    public void TreeCreated(DbCommandTreeInterceptionContext interceptionContext)
    {
        ...
    
        if (interceptionContext.DbContexts.OfType<DontInterceptContext>().Any())
                return;
