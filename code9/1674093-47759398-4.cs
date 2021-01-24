    private static string Serialize(object obj)
    {
        return JsonConvert.SerializeObject(obj, _settings);
    }
    
    private static object Deserialize(string data)
    {
        return JsonConvert.DeserializeObject(data, _settings);
    }
