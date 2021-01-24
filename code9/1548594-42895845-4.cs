    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }
    
    [ActionName("GetById")
    public string Get(int id)
    {
        return "value";
    }
