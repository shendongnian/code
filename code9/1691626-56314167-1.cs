    var objects = new List<RootObject>();
    var serializer = new JsonSerializer();
    using (var stringReader = new StringReader(content))
    using (var jsonReader = new JsonTextReader(stringReader))
    {
        jsonReader.SupportMultipleContent = true;
        while (jsonReader.Read())
        {
            var json = serializer.Deserialize<RootObject>(jsonReader);
            
            objects.Add(json);
        }
    }
