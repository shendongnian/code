    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(FormCollection fc)
    {
        int res = dblayer.Admin_Login(fc["Email"], fc["Password"]);
        if (res == 1)
        {
            return RedirectToAction("Edit");
        }
        else 
        {
            return RedirectToAction("Create");
        }
    }
    public ActionResult Create()
    {
        return View();
    }
    public ActionResult Edit()
    {
        return View();
    }
