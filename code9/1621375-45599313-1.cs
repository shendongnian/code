    buyer = new JArray();
    if (fieldList.Any())
    {
        foreach (var properties in fieldList)
        {
            dynamic savableObject = new JObject();
            foreach (var property in properties.Group)
            {
                savableObject.Add(property.FieldName, property.Value);
            }
         buyer.Add(savableObject);
        }
    }
