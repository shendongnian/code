    public IHttpActionResult Post([FromBody]SomeObject value)
    {
        if(this.ModelState.IsValid)
        {
            // If you enter here all data are set correctly
            return Ok();
        }
        else
        {
            // here you use BadRequest method and pass the ModelState property.
            return this.BadRequest(this.ModelState);
        }
    }
