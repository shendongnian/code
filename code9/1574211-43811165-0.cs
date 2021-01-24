    public ActionResult Details(int? id, string returnUrl = null)
    {
        ...
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }
