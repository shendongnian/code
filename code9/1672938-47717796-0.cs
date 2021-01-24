    private JToken GetValueByKey(JObject jObject, string key)
    {
        foreach (KeyValuePair<string, JToken> jProperty in jObject)
        {
            if (jProperty.Key.Equals(key))
            {
                return jProperty.Value;
            }
            else if (jProperty.Value is JObject)
            {
                return GetValueByKey((JObject)jProperty.Value, key);
            }
        }
        return null;
    }
