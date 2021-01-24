    public static class DbContextExtensions
    {
        public static IQueryable<Object> Set(this DbContext _context, Type t)
        {
            return (IQueryable<Object>)_context.GetType().GetMethod("Set").MakeGenericMethod(t).Invoke(_context, null);
        }
        public static IQueryable<Object> Set(this DbContext _context, String table)
        {
            Type TableType = _context.GetType().Assembly.GetExportedTypes().FirstOrDefault(t => t.Name == table);
            IQueryable<Object> ObjectContext = _context.Set(TableTypeDictionary[table]);
            return ObjectContext;
        }
    }
