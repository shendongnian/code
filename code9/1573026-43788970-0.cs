    public ContentResult Something()
    {
        var literalJson = "{\"a\":1,\"b\":2}";
        var resp = new
        {
            result = "success",
            responseTime = DateTimeOffset.Now,
            data = new Newtonsoft.Json.Linq.JRaw(literalJson)
        };
        return Content(JsonConvert.SerializeObject(resp), "application/json", Encoding.UTF8);
    }
