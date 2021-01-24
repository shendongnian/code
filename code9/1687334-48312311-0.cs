    public static string ToJSON(this Object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
    public static T FromJSON<T>(string jsonData)
    {
        return JsonConvert.DeserializeObject<T>(jsonData);
    }
