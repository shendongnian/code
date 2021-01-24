    public static Task<string> Convert(string payload, Type type)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings().Configure();//<--- Pull in extension methods to handle custom types
        return JsonConvert.SerializeObject(JsonConvert.DeserializeObject(payload, type), settings));
    }
