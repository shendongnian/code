    public static Dictionary<string, string> Deserialize(string json)
    {
        return JObject.Parse(json)
            .SelectToken("CustomData[0].Wrapper[0].OptionalDataSet1")
            .Children<JObject>()
            .SelectMany(jo => jo.Properties())
            .ToDictionary(jp => jp.Name, jp => (string)jp.Value);
    }
