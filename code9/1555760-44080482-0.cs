    [HttpPost]
    [AllowAnonymous]
    public IActionResult GetToken()
    {
       string cookieToken, formToken;
       System.Web.Helpers.AntiForgery.GetTokens(null, out cookieToken, out formToken);
       return this.Ok(cookieToken + ":" + formToken);
    }
