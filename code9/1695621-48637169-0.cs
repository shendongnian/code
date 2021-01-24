    public string SelectQuery<T>() where T : class
    {
        var selectQuery = new List<string>();
        foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            var attr = prop.GetAttribute<ColumnAttribute>();
            selectQuery.Add(attr != null ? $"{attr.Name} as {prop.Name}" : prop.Name);
        }
        return string.Join(", ", selectQuery);
    }
