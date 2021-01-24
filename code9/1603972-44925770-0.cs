    private string ConvertCollectionToCsv<T>(IEnumerable<T> items, string propertyName)
    {
       var prop = typeof(T).GetProperties().FirstOrDefault
       (p => p.Name.ToLowerInvariant() == propertyName.ToLowerInvariant());
    
       var list = items.Select(p => prop.GetValue(p)).ToArray();
       return string.Join(";", list);
    }
