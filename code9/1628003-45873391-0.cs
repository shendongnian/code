    using (var streamReader = new StreamReader(fileName))
    {
        using (var jsonReader = new JsonTextReader(streamReader))
        {
            var serializer = JsonSerializer.Create(new JsonSerializerSettings() { Converters = new List<JsonConverter> { jsonConverter }});
            return jsonConverter == serializer.Deserialize<IList<T>>(jsonReader);
        }
    }
