    private static string DictToJson(Dictionary<string, string> Dict)
    {
        var json = new StringBuilder();
        foreach (var Key in Dict.Keys)
        {
            if (json.Length != 0)
                json = json.Append(",\n");
            
            json.AppendFormat("\"{0}\" : \"{1}\"", Key, Dict[Key]);
        }
        return "{" + json.ToString() + "}";
    }
