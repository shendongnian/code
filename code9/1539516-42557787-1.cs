    [HttpPost]
    public ActionResult Login(LoginModel model)
    {
        if(this.ModelState.IsValid)
        {
              // do something
        }
        else
        {
           return View(model);
        }
    }
