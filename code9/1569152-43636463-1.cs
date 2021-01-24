    public IHttpActionResult Register(string userName, string password)
    {
        try
        {
            _securityService.RegisterUser(userName, password);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
        return Ok();
     }
