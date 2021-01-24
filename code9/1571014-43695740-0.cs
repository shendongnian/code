    [Route("api/***/***")]
    [HttpGet]
    public IHttpActionResult Clear****()
    {
        // do not use try catch here
        //try
        //{
            // try clearing
        //}
        //catch(Exception e)
        //{
            //throw new CustomRestErrorHandlerException();     << error occurs here 
        //}
        throw new Exception();
    }
