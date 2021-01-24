    [HttpPost]
    public ActionResult AddOrFinish(Student model, string add, string issue)
    {
        if (ModelState.IsValid)
        {
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
    }
