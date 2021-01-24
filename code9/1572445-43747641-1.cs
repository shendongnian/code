    JsonSerializer serializer = new JsonSerializer();
    MyObject o;
    using (FileStream s = File.Open("bigfile.json", FileMode.Open))
    using (StreamReader sr = new StreamReader(s))
    using (JsonReader reader = new JsonTextReader(sr))
    {
        while (sr.Read())
        {
            // deserialize only when there's "{" character in the stream
            if (sr.TokenType == JsonToken.StartObject)
            {
                o = serializer.Deserialize<MyObject>(reader);
            }
        }
    }
