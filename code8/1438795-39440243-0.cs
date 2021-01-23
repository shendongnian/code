    public static List<T> Deserialize<T>(string json, string attribute)
    {
        return JArray.Parse(json)
                     .Children<JObject>()
                     .Where(jo => jo[attribute] != null)
                     .Select(jo => jo.ToObject<T>())
                     .ToList();
    }
