    using (StreamReader sr = new StreamReader("D:\\Hun\\enplays.json"))
    using (JsonTextReader reader = new JsonTextReader(sr))
    {
        var serializer = new JsonSerializer();
        while (reader.Read())
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                // Deserialize each object from the stream individually and process it
                var playdata = serializer.Deserialize<playdata>(reader);
                ProcessPlayData(playdata);
            }
        }
    }
