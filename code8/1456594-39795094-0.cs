    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        Debug.Log("Reading json");
        if (reader.TokenType == JsonToken.Null)
            return null;
        return AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.GUIDToAssetPath(existingValue as string));
    }
