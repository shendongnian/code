    [HttpPost]
    public ActionResult Edit(ViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Do something
            if (Session["ReturnUrl"] != null)
                return Redirect(Session["ReturnUrl"].ToString());
        }
        // If we got this far, something failed, redisplay form
        return View(model);
    } 
