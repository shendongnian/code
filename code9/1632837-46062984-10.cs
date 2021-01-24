    [HttpPost]
    public ActionResult AddOrFinish(Student model, string add, string issue)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        if (!string.IsNullOrEmpty(add))
        {
            // do your add logic
        }
        else
        {
            // do your finish logic
            return RedirectToAction("ViewIssue");
        }
    }
