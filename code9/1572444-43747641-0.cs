    JsonSerializer serializer = new JsonSerializer();
    MyObject o;
    using (FileStream s = File.Open("bigfile.json", FileMode.Open))
    using (StreamReader sr = new StreamReader(s))
    using (JsonReader reader = new JsonTextReader(sr))
    {
        while (sr.Read())
        {
            if (sr.TokenType == JsonToken.StartObject)
            {
                var jObject = JObject.Load(reader);
                o = jObject.ToObject<MyObject>();
            }
        }
    }
