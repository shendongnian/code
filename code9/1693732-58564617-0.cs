    private static void ChangePropertiesToLowerCase(JObject jsonObject)
    {
        foreach (var property in jsonObject.Properties().ToList())
        {
            if (property.Value.Type == JTokenType.Object) // replace property names in child object
                ChangePropertiesToLowerCase((JObject)property.Value);
    
            if (property.Value.Type == JTokenType.Array)
            {
                var arr = JArray.Parse(property.Value.ToString());
                foreach (var pr in arr)
                {
                    ChangePropertiesToLowerCase((JObject)pr);
                }
    
                property.Value = arr;
            }
    
            property.Replace(new JProperty(property.Name.ToLower(CultureInfo.InvariantCulture), property.Value)); // properties are read-only, so we have to replace them
        }
    }
