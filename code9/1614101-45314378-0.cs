    [Route("api/Foo/MyController/{id}")]
    public IHttpActionResult Get(int? id = null)
    {
        IQueryable foo = GetData();
        if (id.HasValue)
        {
            foo = foo.Where(e => e.Id == id.Value);
        }
        //...
    }
