    public static class JsonSerialiation
    {
        public static string Serialize<T>(T obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (JsonTextWriter writer = new JsonTextWriter(new StreamWriter(stream))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serializer(writer, obj);
                    writer.Flush();
                    stream.Position = 0;
                    using (StreamReader reader = new StreamREader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
    
        public static T Deserialize<T>(string jsonString)
        {
            using (JsonTextReader reader = new JsonTextReader(new StringReader(str)))
            {
                JsonSerializer serializer = new JsonSerializer();
                return serializer.Deserialize<T>(reader)
            }
        }
    }
