    public ActionResult YourControllerMethod(YourViewModel model)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("B");
        }
        else 
        {
            ViewData.Model = model; //where model is your controller model
            return View(); // when validation failed
        }
    }
