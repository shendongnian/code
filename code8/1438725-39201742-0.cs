    [Route("api/identity/{controller}/{id}", Order = 1)]
    [HttpGet]
    public IHttpActionResult DoSomethingHere(int id)
    {
        // Do some magic here
    }
