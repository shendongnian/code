    public static T DeserializeCompressed<T>(Stream stream, JsonSerializerSettings settings = null)
    {
       using (var compressor = new GZipStream(stream, CompressionMode.Decompress))
       using (var reader = new StreamReader(compressor))
       using (var jsonReader = new JsonTextReader(reader))
       {
          var serializer = JsonSerializer.CreateDefault(settings);
           return serializer.Deserialize<T>(jsonReader);
       }
    }
