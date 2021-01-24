    JArray a = JArray.Parse(jsonString);
    // dictionary hold the key-value pairs now
    Dictionary<string.string> dict = new Dictionary<string.string>();
    foreach (JObject o in a.Children<JObject>())
    {
        foreach (JProperty p in o.Properties())
        {
            string name = p.Name;
            string value = (string)p.Value;
            dict.Add(name,value);
        }
    }
