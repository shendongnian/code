    [HttpPost]
    public async Task<IHttpActionResult> Create([FromBody] AType payload)
    {
        if (payload == null) 
        {
            return BadRequest("Must provide payload");
        }
    
        await Task.Delay(1);
    
        var t = new T { Id = 0, Name = payload.tName, Guid = Guid.NewGuid() };
    
        var response = new MyResponse { T = t };
    
        return Ok(response);
    }
