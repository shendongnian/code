    public async Task Invoke(HttpContext context)
    {
        ...
        // parse json
        var bodyJson = JObject.Parse(bodyString);
        // do something with json inner objects
        bodyJson = ...
        // update the memory stream
        var bytes = Encoding.UTF8.GetBytes(bodyJson.ToString());
        ...
    }
