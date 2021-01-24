    bool IsDbSet(Type t) {
        if (!t.IsGenericType) {
            return false;
        }
        return typeof(DbSet<>) == t.GetGenericTypeDefinition(t);
    }
