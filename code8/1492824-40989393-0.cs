    private static void ReadPropertiesRecursive<Tt>(Tt obj, Type type, List<string> prefixes)
    {
        foreach (PropertyInfo property in type.GetProperties())
        {
            if (property.PropertyType.GetTypeInfo().IsClass && property.PropertyType != typeof(string))
            {
                prefixes.Add(property.Name);
                var val = property.GetValue(obj);
                if (val == null)
                    val = Activator.CreateInstance(property.PropertyType);
                property.SetValue(obj, val);
                ReadPropertiesRecursive(val, property.PropertyType, prefixes);
                prefixes.Remove(property.Name);
            }
            else
            {
                var propertyFullName = prefixes != null && prefixes.Count > 0 ? $"{prefixes.Aggregate((i, j) => i + "." + j)}.{property.Name}" : property.Name;
                    
                property.SetValue(obj, dic[propertyFullName]);
                Console.WriteLine(propertyFullName);
            }
        }
    }
