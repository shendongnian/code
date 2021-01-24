    if (!Request.IsAuthenticated)
    {
       HttpContext.Current.GetOwinContext().Authentication.Challenge(
       new AuthenticationProperties() { RedirectUri = "/" }, Startup.SignUpPolicyId);
    }
