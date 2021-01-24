    foreach(var property in testCompanyUser.GetType().GetProperties(BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Public).Where(p => p.PropertyType.BaseType == typeof(BaseDomainModel)))
    {
        var method = property.PropertyType.GetMethod("ValidateModel", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        object propValue = property.GetValue(testCompanyUser);
        if(method != null && propValue != null)
        {
            m.Invoke(propValue, null);
        }
