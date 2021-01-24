    public static string Serialize<T>(object obj) where T : Attribute
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ContractResolver = new CustomResolver<T>(),
            Formatting = Formatting.Indented
        };
        return JsonConvert.SerializeObject(obj, settings);
    }
