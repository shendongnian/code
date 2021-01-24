    public string GetDbTable<T>() where T : DbItem
    {
        var attr = typeof(T).GetCustomAttributes(
            typeof(DbTableAttribute), true
        ).FirstOrDefault() as DbTableAttribute;
        return attr?.Name;
    }
