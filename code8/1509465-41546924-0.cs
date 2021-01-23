    public IHttpActionResult ExampleGet(string query)
    {
        var result = JsonConvert.DeserializeObject<IDictionary<string, IDictionary<string, IDictionary<string, bool>>>>(query);
        ...
    }
