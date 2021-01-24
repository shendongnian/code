    public List<T> GetSome(YourDbContext db, string tableName) where T : class
    {
        return db.Set<T>()
                 .FromSql("SPNAME @tablename={0}", tableName)
                 .ToList();         
    }
