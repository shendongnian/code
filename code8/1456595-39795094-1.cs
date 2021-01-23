    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        Debug.Log("Reading json");
        if (reader.TokenType == JsonToken.Null)
            return null;
        var guid = (string)JToken.Load(reader); // Load the GUID value
        return AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.GUIDToAssetPath(guid));
    }
