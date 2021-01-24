    foreach (var propertyInfo in large.GetType().GetProperties())
    {
        var sm = smalls.FirstOrDefault(small => string.Equals(small.Name, propertyInfo.Name, StringComparison.InvariantCultureIgnoreCase));
        if (sm != null)
            propertyInfo.SetValue(large, Convert.ChangeType(sm.Value, propertyInfo.PropertyType), null);
    }
