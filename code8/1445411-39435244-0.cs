    [SwaggerOperation("get")]
    public IEnumerable<Contact> Get()
    {
        ....
    }
    
    [SwaggerOperation("getById")]
    public IEnumerable<Contact> Get(string id)
    {
        ...
    }
