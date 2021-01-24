    foreach (PropertyInfo prop in Props)
    {
        var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.
        dataTable.Columns.Add(prop.Name, type);
    }
