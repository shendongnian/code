    byte[] payload = ...; // get bytes from Payload column
    var settings = new JsonSerializerSettings {PreserveReferencesHandling = PreserveReferencesHandling.Objects};
    using (var stream = new MemoryStream(payload))
    using (var reader = new StreamReader(stream))
    {
        var domainEvent =  JsonConvert.DeserializeObject(reader.ReadToEnd(), settings);
    }
