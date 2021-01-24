    [HttpGet]
    public async Task<MyObject> Get()
    {
        var data = await _task.GetMyObject()
        if(data == null)
        {
            return NotFound(); //Or, return Request.CreateResponse(HttpStatusCode.NotFound)
            // Versus, throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }
        return Ok(data);
    }
