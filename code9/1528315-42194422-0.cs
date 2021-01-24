    public static HashEntry[] ToHashEntries(this object obj)
    {
        PropertyInfo[] properties = obj.GetType().GetProperties();
        return properties
            .Where(x => x.GetValue(obj) != null) // <-- PREVENT NullReferenceException
            .Select
            (
                  property => 
                  {
                       object propertyValue = property.GetValue(obj);
                       string hashValue;
                       // This will detect if given property value is 
                       // enumerable, which is a good reason to serialize it
                       // as JSON!
                       if(propertyValue is IEnumerable<object>)
                       {
                             // So you use JSON.NET to serialize the property
                             // value as JSON
                             hashValue = JsonConvert.SerializeObject(propertyValue);
                       }
                       else
                       {
                            hashValue = propertyValue.ToString();
                       }
                       return new HashEntry(property.Name, hashValue);
                  }
            )
            .ToArray();
    }
