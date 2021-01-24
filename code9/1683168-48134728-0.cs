    public static T ToOject<T>(this XElement element) where T : class, new()
    {
        try
        {
            T instance = new T();
            foreach (var property in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var xattribute = element.Attribute(property.Name);
                var xelement = element.Element(property.Name);
                var propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                var value = xattribute?.Value ?? xelement.Value;
                try
                {
                    if (value != null)
                    {
                        if (property.CanWrite)
                        {
                            property.SetValue(instance, Convert.ChangeType(value, propertyType));
                        }
                    }
                }
                catch // (Exception ex) // If Error let the value remain default for that property type
                {
                    Console.WriteLine("Not able to parse value " + value + " for type '" + property.PropertyType + "' for property " + property.Name);
                }
            }
            return instance;
        }
        catch (Exception ex)
        {
            return default(T);
        }
    }
