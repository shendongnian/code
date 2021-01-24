    public ActionResult LogOff()
    {
      AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
      Session.Abandon();
      Session.Clear();
      Response.Cookies.Clear();
      Session.RemoveAll();
      Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
      return RedirectToAction("Login", "Account");
    }
