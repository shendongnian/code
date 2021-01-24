    [HttpPost]
    public ActionResult Register(RegistrationModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
       
        // model is valid so do whatever you need to
        // such as saving to db etc.
        // Here do a redirect to some other page
        return RedirectToAction("Index", "Home");
    }
