    public ActionResult YourAction(SomeModel model)
    {
       if (ModelState.IsValid)
       {
         return RedirectToAction("B");
       }
       else 
       {
        return View(model);
       }
    
    }
