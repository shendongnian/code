    {
    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
    Response.Cache.SetNoStore();
    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
    return RedirectToAction("Login");
    }
