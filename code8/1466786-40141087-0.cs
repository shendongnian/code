    public ActionResult SomeAction()
    {
       TempData["data"]= new CP_Sales_App_LC();
       return RedirectToAction("Index", "CPLCReservation");
    }
    public ActionResult Index()
    {
       CP_Sales_App_LC data = (CP_Sales_App_LC)TempData["data"];
       return View(data);
    }
