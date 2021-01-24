    //private method
    private IActionResult GetThingPrivate()
    {
       //your Code here
    }
    //Jwt-Method
    [Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme}")]
    [HttpGet("bearer")]
    public IActionResult GetByBearer()
    {
       return GetThingsPrivate();
    }
     //Cookie-Method
    [Authorize(AuthenticationSchemes = $"{CookieAuthenticationDefaults.AuthenticationScheme}")]
    [HttpGet("cookie")]
    public IActionResult GetByCookie()
    {
       return GetThingsPrivate();
    }
