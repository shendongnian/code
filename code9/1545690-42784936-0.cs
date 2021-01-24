    public void All()
    {
        var properties = typeof (Context).GetProperties().Where(p => IsSubclassOfRawGeneric(typeof(DbSet<>), p.PropertyType));
        foreach (PropertyInfo property in properties)
        {
            Type entityType = property.PropertyType.GetGenericArguments()[0];
            // ...
        }
    }
    static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
    {
        while (toCheck != null && toCheck != typeof(object))
        {
            var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
            if (generic == cur)
            {
                return true;
            }
            toCheck = toCheck.BaseType;
        }
        return false;
    }
