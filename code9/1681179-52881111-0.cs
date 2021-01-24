    public static class DbContextExtensions
    {
        public static IQueryable<Object> Set(this DbContext _context, Type t)
        {
            return (IQueryable<Object>)_context.GetType().GetMethod("Set").MakeGenericMethod(t).Invoke(_context, null);
        }
        public static IQueryable<Object> Set(this DbContext _context, String table)
        {
            Dictionary<String, Type> TableTypeDictionary = _context.GetType().Assembly.GetExportedTypes().ToDictionary(t => t.Name, f => f);
            IQueryable<Object> ObjectContext = _context.Set(TableTypeDictionary[table]);
            return ObjectContext;
        }
    }
