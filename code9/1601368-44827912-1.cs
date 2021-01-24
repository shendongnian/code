    PropertyInfo[] props = myObject.GetType().GetProperties();
    foreach (var propInfo in props)
    {
        if (person.ContainsKey(propInfo.Name))
        {
            propInfo.SetValue(myObject, person[propInfo.Name]);
        }
    }
