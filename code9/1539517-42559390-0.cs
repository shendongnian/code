    [HttpPost]
    public ActionResult Login(LoginModel model)
    {
        if(string.IsNullOrWhiteSpace(model.UserName)
        {
              ModelState.AddModelError("UserName","This field is required!");
              return View(model);
        }
    
        /* Same can be done for password*/
    
        /* I am sure once the user has logged in successfully.. you won't want to return the same view, but rather redirect to another action */
    
        return RedirectToAction("AnotherAction","ControllerName");
    
    }
