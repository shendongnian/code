    public static ObjectType Patch<ObjectType>(ObjectType source, JObject document)
        where ObjectType : class
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
    
        try
        {
            String currentEntry = JsonConvert.SerializeObject(source, settings);
    
            JObject currentObj = JObject.Parse(currentEntry);
    
            foreach (KeyValuePair<String, JToken> property in document)
            {    
                currentObj[property.Key] = property.Value;
            }
    
            String updatedObj = currentObj.ToString();
    
            return JsonConvert.DeserializeObject<ObjectType>(updatedObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
