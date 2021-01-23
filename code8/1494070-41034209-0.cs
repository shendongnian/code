    public ActionResult Index()
    {
        //ViewBag.TheMessageIs = "this is the message";
        return RedirectToAction("Details", new { id = 1, TheMessageIs = "this is the message" });
    }
    public ActionResult Details(int id, string TheMessageIs)
    {
        ViewBag.TheMessageIs = TheMessageIs;
        return View();
    }
