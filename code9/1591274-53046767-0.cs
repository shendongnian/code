    routes.MapRoute(
      "DesktopLogin",
      "{controller}/account/Function1",
      new { controller = "My", action = "Login" }
     );
     routes.MapRoute(
    "NewDeskTopLogin",
     "{controller}/account/Function1",
     new { controller = "My", action = "Login" }
     );
     ///////////RouteAttribute and HttpPost together on same action
 
    [Route("DesktopLogin")]
    public ActionResult Function1(LoginModel model)
    {
      return View("~/Views/Account/Login.cshtml");
     }
    [Route("NewDeskTopLogin")]
    [HttpPost]
    public ActionResult Function1(LoginModel model)
    {
      return View("~/Views/Account/Login.cshtml");
    }
