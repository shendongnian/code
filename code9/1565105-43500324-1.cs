    public static string Serialize(object obj, Type attributeTypeToLookFor)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ContractResolver = new CustomResolver(attributeTypeToLookFor),
            Formatting = Formatting.Indented
        };
        return JsonConvert.SerializeObject(obj, settings);
    }
