    static List<Dictionary<string, string>> GetResultsFromResponseStream(Stream responseStream)
    {
        using (StreamReader streamReader = new StreamReader(responseStream))
        using (JsonReader jsonReader = new JsonTextReader(streamReader))
        {
            JObject obj = JObject.Load(jsonReader);
            JArray keys = (JArray)obj["header"];
            List<Dictionary<string, string>> results = obj["results"]
                .Children<JArray>()
                .Select(a => keys.Zip(a, (k, v) => new { Key = (string)k, Value = (string)v })
                                 .ToDictionary(kvp => kvp.Key, kvp => kvp.Value))
                .ToList();
            return results;
        }
    }
