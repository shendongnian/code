    public void Post([FromBody]Class1 value)
    {
        var s = Newtonsoft.Json.JsonConvert.SerializeObject(value);
        // use s now.
    }
