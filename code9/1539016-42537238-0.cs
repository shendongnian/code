    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult LoginUserType1(User1 u)
    {
        if (ModelState.IsValid) 
        {
            //My Code
        }
        return View(u);
    }
    ..
    ..
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult LoginUserType2(User1 u)
    {
        if (ModelState.IsValid) 
        {
            //My Code
        }
        return View(u);
    }
