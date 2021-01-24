    // POST: /Account/LogOff
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult LogOff()
    {
        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        var idpClaim = ClaimsPrincipal.Current.Claims.FirstOrDefault(claim => { return claim.Type == "idp"; });
        if (idpClaim!=null)
            HttpContext.GetOwinContext().Authentication.SignOut(
                OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);
      
        return RedirectToAction("Index", "Home");
    }
