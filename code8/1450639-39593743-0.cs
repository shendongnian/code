    public ActionResult Login(YourLoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            //Your Login logic here
        }
        else
        {
            return View(model)
        }
    }
