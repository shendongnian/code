    Which type of Authentication are you using?
    
    If you are using FormsAuthentication then use this code in your logOff Method
    
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
    
    Also use MVC's AuthorizeRoles attribute to make sure user redirects to login page once logged out
    
    [AuthorizeRoles(UserRole.SocietyAdmin, UserRole.ClientAdmin)]
    //Your ActionResult here
    public ActionResult Index()
    {
    return View();
    }
    
    Now whenever user is logged out of any authorized Page, he will go directly to login page when clicking back button.
