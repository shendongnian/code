    [HttpPost]
    [AllowAnonymous]
    [Route("Login")]
    public async Task<ActionResult> Login(CommonViewModel model)
    {
     var loginmodel= model.LoginModel; //here you can access the properties like loginmodel.Password
    }
