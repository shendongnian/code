    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var type = (string)reader.Value;
        switch (type)
        {
            case "A": return SearchResultType.Article;
            case "D": return SearchResultType.Disambuigation;
            ...
            default: return SearchResultType.None;
        }
    }
