    if (!Request.IsAuthenticated && AttemptSSO)
    {
        ReturnURL = Request.QueryString["ReturnUrl"];
        HttpContext.Current.GetOwinContext().Authentication.Challenge(new AuthenticationProperties { RedirectUri = "/Login.aspx" }, OpenIdConnectAuthenticationDefaults.AuthenticationType);
     }
     else if (Request.IsAuthenticated && AttemptSSO)
     {
         if (!string.IsNullOrEmpty(ReturnURL))
         {
               var url = ReturnURL;
               ReturnURL = "";
               Response.Redirect(ResolveUrl(url));
         }
         else
         {
                Response.Redirect(ResolveUrl("~/Default.aspx"));
         }
     }
