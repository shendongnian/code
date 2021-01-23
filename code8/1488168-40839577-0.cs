    public ActionResult CreateDomainName()
    {
       return View();
    }
    [HttpPost]
    public ActionResult CreateDomainName(Domeinnaam model)
    {
       if(ModelState.IsValid)
       {
          //Your code to save
       }
       return RedirectToAction("Index");
    }
