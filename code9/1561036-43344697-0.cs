    dynamic data = Json.Decode(jsonString);
    
    foreach(var property in typeof(MyJsonClass).GetProperties().Where(p => p.PropertyType.IsValueType))
    {
        if(data[property.Name] == null)
        {
            Console.WriteLine($"This is problematic property: {property.Name}");
        }
    }
