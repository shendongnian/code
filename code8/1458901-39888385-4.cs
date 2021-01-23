    public static string Remove(string json, string stateToKeep)
    {
        JObject jo = JObject.Parse(json);
        jo["States"] = new JArray(stateToKeep);
        return jo.ToString();
    }
