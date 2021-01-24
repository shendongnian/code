    public static T PatchObject<T>(T source, JObject document) where T : class
    {
        Type type = typeof(T);
        IDictionary<String, Object> dict = 
            type
                .GetProperties()
                .ToDictionary(e => e.Name, e => e.GetValue(source));
        string json = document.ToString();
        var patchedObject = JsonConvert.DeserializeObject<T>(json);
        foreach (KeyValuePair<String, Object> pair in dict)
        {
            foreach (KeyValuePair<String, JToken> node in document)
            {
                string propertyName =   char.ToUpper(node.Key[0]) + 
                                        node.Key.Substring(1);
                if (propertyName == pair.Key)
                {
                    PropertyInfo property = type.GetProperty(propertyName);
                    property.SetValue(source, property.GetValue(patchedObject));
                    break;
                }
            }
        }
        return source;
    }
