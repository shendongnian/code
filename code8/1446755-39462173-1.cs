    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>)) type = Nullable.GetUnderlyingType(type);
    
    // test attribute to see if it is shown
    if (propertyDescriptor.Attributes.Contains(new DontShowMe())) continue;
    
    dataTable.Columns.Add(propertyDescriptor.Name, type);
