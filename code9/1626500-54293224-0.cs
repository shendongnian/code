    public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = "")
    {
        ....... other codes
     
        if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
           return Redirect(returnUrl);
        else
           return RedirectToAction("Index", "Home");
    }
