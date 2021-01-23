    public static string Remove(string json)
    {
        var obj = JObject.Parse(json);
        var result = obj["States"].Select(s =>
        {
            var clone = s.Root.DeepClone();
            clone["States"] = new JArray(s);
            return clone;
        });
        return new JArray(result).ToString();
    }
