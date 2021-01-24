    //Action With Parameter 
    public ActionResult ClosedEvents(string searchBy, string search, int page = 1, int pageSize = 20, bool falsPositive = false) 
    { 
    }
    //And your routing should be :
    routes.MapRoute( 
    "history", // Route name 
    "{controller}/{action}/{searchBy}/{search}/{page}/{pageSize}/{falsPositive}", // URL with parameters 
    new { controller = "Teum", action = "ClosedEvents", searchBy = "", search = "",page="",pageSize="",falsPositive="" } // Parameter defaults 
    );
 
