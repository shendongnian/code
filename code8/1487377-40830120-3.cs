    [HttpGet]
    [AllowAnonymous]
    public ActionResult Login() {
        var model = new LoginModel();//also why default constructor needed
        return View(model);
    }
    
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public ActionResult Login(LoginModel model, string returnUrl)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        //...login logic here
        //if reach this far then redirect
        if (!string.IsNullOrWhiteSpace(returnUrl)) {
            return RedirectToLocal(returnUrl);
        } else {
            return this.RedirectToAction("MyActionNameHere");
        }
    }
