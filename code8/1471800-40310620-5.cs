    public async Task<IHttpActionResult<YourClass>> Get()
    {
        var yourclass = new YourClass();
        return new IHttpActionResult<YourClass>(yourclass, HttpStatusCode.OK, Request, Configuration);
    }
