    [HttpGet]
    [Route("~/api/v3/login/{username}/{password}")]
    [ResponseType(typeof(LoginResult))]
    public LoginResult GetLoginInfo3(string username, string password) {
        //v3 logic
    }
