    [HttpPost]
    public ActionResult Edit(ViewModel model, string returnUrl)
    {
        if (ModelState.IsValid)
        {
            // Do something
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
        }
        // If we got this far, something failed, redisplay form
        return View(model);
    }
