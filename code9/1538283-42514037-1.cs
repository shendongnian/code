    Public ActionResult Index()
    {
      If(user is logged in already)
      {
         Return RedirectToAction("dashboard","manage");
       }
    // code something
    }
