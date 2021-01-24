    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        return reader
                .Value
                .ToString()
                .Split(new char[]{' ', ',', '+'}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
    }
