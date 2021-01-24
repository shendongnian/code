    foreach (PropertyInfo prop in props) {
        // Setting column names as Property names.
        if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            dataTable.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
        else
            dataTable.Columns.Add(prop.Name, prop.PropertyType);
    }
