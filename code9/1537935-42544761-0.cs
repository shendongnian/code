    JObject fields = new JObject();
    foreach (var property in ((JObject)response.SelectToken("$.item.elements")).Properties())
    {
        // Remove underscore characters to support loading into PascalCase property names in CSharp code
        string propertyName = property.Name.Replace("_", "");
        fields.Add(propertyName, property.First["value"]);
    }
    return fields.ToObject<T>();
