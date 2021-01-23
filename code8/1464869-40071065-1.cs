    // POST: /Account/Register
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new user() { UserName = model.UserName, /*... other fields */ };
            // Save user
        }
        // If we got this far, something failed, redisplay form
        return View(model);
    }
