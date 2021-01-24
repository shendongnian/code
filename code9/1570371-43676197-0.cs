    JArray a = JArray.Parse(jsonString);
    Dictionary<string.string> = new Dictionary<string.string>();
    foreach (JObject o in a.Children<JObject>())
    {
        foreach (JProperty p in o.Properties())
        {
            string name = p.Name;
            string value = (string)p.Value;
            dict.Add(name,value);
        }
    }
    // dictionary hold the key-value pairs now
    dict
