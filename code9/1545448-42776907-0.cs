    public ActionResult Results(Models.InternshipModel mod)
    {
          ViewBag.Message = "This is the results page.";
          ViewBag.Changes = mod.Title;  //User input, not default 'Title'
          return View();
    }
