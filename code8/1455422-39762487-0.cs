    public static IEnumerable<object> GetList(string entityName)
    {
        Type entityType = Type.GetType(string.format("Namespace.{0}, MyAssembly", entityName);
        DbSet dbSet = DbContext.Set(entityType);
        // DbSet implements IEnumerable, so you will be able to safely cast it like so.
        // Or you can assign it to IEnumerable directly.
        IEnumerable list = dbSet as IEnumerable;
        return list.Cast<object>.ToList();
    }
