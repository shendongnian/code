    [AppSettingsDynamicRolesAuthorize(Role.Administrator, Role.OtherRole)]
    [HttpGet]
    [Route("Test")]
    public IHttpActionResult Get()
    {
        var userName = RequestContext.Principal.Identity.Name;
        var user = HttpContext.Current.User.Identity;
        return Ok("It works!");
    }
