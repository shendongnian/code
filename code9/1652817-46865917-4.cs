    public void Post(Class1 value)
    {
        var stringVersion = Newtonsoft.Json.JsonConvert.SerializeObject(value);
        // use stringVersion  now.
    }
