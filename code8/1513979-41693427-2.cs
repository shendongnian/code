    public static void FlattenJson(JObject node, JObject result, string prefix = "")
    {
        foreach (var jprop in node.Properties())
        {
            if (jprop.Children<JObject>().Count() == 0)
            {
                result.Add(prefix + jprop.Name, jprop.Value);
            }
            else
            {
                FlattenJson((JObject)jprop.Value, $"{prefix}{jprop.Name}__", result);
            }
        }
    }
