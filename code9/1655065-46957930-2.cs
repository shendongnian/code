    [HttpPost]
    public ActionResult Create(CreateUserVm model)
    {
       if(ModelState.IsValid) 
       {
          // all good. Save
          return RedirectToAction("Index");     
       }
       return View(model);
    }
