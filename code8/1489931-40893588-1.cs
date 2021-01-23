    [HttpGet]
    public IHttpActionResult Service1()
    {
       var result = new ServiceLogin1().Execute();
       if(result == null)
       {
              return StatusCode(HttpStatusCode.NoContent);
       }
       else
       {
              return Ok();
       }
    }
