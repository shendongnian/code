    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(MyViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
    //do something!
    }
