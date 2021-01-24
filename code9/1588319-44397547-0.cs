    var client = new HttpClient();
    var dtoContent = new PushStreamContent((stream, content, context) => {
       var serializer = new JsonSerializer();
        using (var streamWriter = new StreamWriter(stream))
        {
           using (var jsonWriter = new JsonTextWriter(streamWriter))
           { serializer.Serialize(jsonTextWriter, dto); }
        }
    });
    using (var stream = await client.PostAsync(url, dtoContent).Content.ReadAsStreamAsync())
    {
      using (var streamReader = new StreamReader(stream))
      {
        using (var jsonReader = new JsonTextReader(streamReader))
        {
            document = JsonSerializer().Deserialize<Document>(jsonReader);
        }
      }
    }
