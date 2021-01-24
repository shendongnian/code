    JsonSerializerSettings settings = new JsonSerializerSettings
    {
          MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
          DateParseHandling = DateParseHandling.None
    };
    
    var movie = JsonConvert.DeserializeObject<Movie>(json,settings);
