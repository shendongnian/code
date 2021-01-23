    public ActionResult Login(string modelState = null)
    {
        if (modelState != null)
            ModelState.AddModelError("", Resource.MSG_USER_NOT_CONFIRMED);
        return View();
    }
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
        AuthenticationManager.SignOut();
        return RedirectToAction("Login", "Controller", new { modelState = "MSG_USER_NOT_CONFIRMED" });
    }
    
