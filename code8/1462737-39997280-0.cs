    // Called with
    // GetFirstObject<myTable>(db);
    public static TEntity GetFirstObject<TEntity>(DbContext context) where TEntity : class
    {
        return context.Set<TEntity>().FirstOrDefault();
    }
