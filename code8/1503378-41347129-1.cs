    public ActionResult addsurvey(Survey srv)
    {
        if (ModelState.IsValid)
        {
            // OK: Save, Proceed and/or Redirect
        }
        else
        {
            // not OK: show View again
            return View(srv);  // or: View("ViewName", srv);
        }
    }
