    [HttpPost]
    public ActionResult AddOrFinish(Student model, string add, string issue)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("PageImOnNow", model);
        }
        if (!string.IsNullOrEmpty(add))
        {
            // do your add logic
            // redirect to some page when user clicks "Add"
            return RedirectToAction("WhateverPageYouWant");
        }
        else
        {
            // do your finish logic
            // redirect to ViewIssue page when user clicks "Finish"
            return RedirectToAction("ViewIssue");
        }
    }
