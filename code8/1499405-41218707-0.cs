    [AllowAnonymous]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Register(string  Email)
    {
        return RedirectToAction("Index", "Home");
    }
