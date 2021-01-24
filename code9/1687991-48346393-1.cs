    [AppSettingsDynamicRolesAuthorize(Role.Administrator, Role.OtherRole)]
    [HttpGet]
    [Route("Test")]
    public IHttpActionResult Get()
    {
        string userName = Environment.UserName;
        var userName2 = RequestContext.Principal.Identity.Name;
        return Ok("It works!");
    }
