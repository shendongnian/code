    [Route("Logout")]
        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(
                OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);
            return View("~/Views/Index/Logout.cshtml");
        }
