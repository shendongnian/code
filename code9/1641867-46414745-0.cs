    [Authorize, HttpPut("{id}")]
    public async Task<bool> Put([FromRoute]string id)
    {
        // Got the id
        var objId = ObjectId.Parse(id);
        // And can now get the body also
        GeoData geoData = null;
        using (StreamReader reader = new StreamReader(HttpContext.Request.Body, Encoding.UTF8))
        {
            geoData = BsonSerializer.Deserialize<GeoData>(reader.ReadToEnd());
        }
        // ...
