    public static ExpandoObject ToExpando(this string s)
    {
        var obj = new ExpandoObject();
        var dictionary = obj as IDictionary<string, object>;       
        var properties = s.Distinct().Select((ch, i) => new { Name = $"C{i+1}", Value = ch });
        foreach (var property in properties)
            dictionary.Add(property.Name, property.Value);
        return obj;
    }
