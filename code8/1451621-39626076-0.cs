    public const string MultiARoute = "multiA/{routesuffix}";
    public const string MultiBRoute = "multiB/subB/{routesuffix}";
    
    [Route(MultiARoute)]
    [Route(MultiBRoute)]
    public ActionResult MultiRoute(string routeSuffix)
    {
    
       var route = this.ControllerContext.RouteData.Route as Route;
       string whatAmI = string.Empty;
    
       if (route.Url == MultiARoute)
       {
          whatAmI = "A";
       }
       else
       {
          whatAmI = "B";
       }
       return View();
    }
