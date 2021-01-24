    public ActionResult SomeAction()
    {
          if(SomeValue)
          return View();
          else 
          return View("Errors/AccessDenied");
    }
