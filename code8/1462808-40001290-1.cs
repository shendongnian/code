    if (verifiedUser != "0")
    {
        //if user is verified
        FormsAuthentication.SetAuthCookie(verifiedUser, true);
        var LoginType = HttpContext.Current.User.Identity.AuthenticationType;
        if (!User.Identity.IsAuthenticated)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
