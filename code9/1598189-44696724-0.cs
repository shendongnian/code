    public static void Dropdown<T>(string name, string key, IEnumerable<T> dataset) where T: class 
    {
        PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.CanRead && (p.Name == name || name == key))
            .ToArray();
        if (properties.Length < 2) throw new ArgumentException("The name and the key properties must exist and the they have to be public");
        var nameprop = properties.First(p => p.Name == name);
        var keyprop = properties.First(p => p.Name == key);
        var data = dataset
            .Select(x => new
            {
                Name = nameprop.GetValue(x, null)?.ToString(),
                Key = keyprop.GetValue(x, null)?.ToString(),
            })
            .ToList();
        // use this as dataspource for your SelectBox 
    }
