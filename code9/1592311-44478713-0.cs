    Html.BeginForm("Login", "Account", new {ReturnUrl = Request.QueryString["ReturnUrl"] })
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginInputModel model, string ReturnUrl) {
    ...
    }
