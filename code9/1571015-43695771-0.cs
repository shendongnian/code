    [Route("api/***/***")]
    [HttpGet]
    public IHttpActionResult Clear****()
    {
        try
        {
            // try clearing
        }
        catch(Exception e)
        {
            throw new ArgumentNullException();     << error occurs here 
        }
        return this.Ok();
    }
