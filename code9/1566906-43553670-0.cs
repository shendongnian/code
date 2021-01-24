    public ActionResult YourActionName()
    {
        if (ModelState.IsValid)
        {
           //do somthing
        }
        return View(); // validation error, so redisplay same view
    }
