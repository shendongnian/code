    // GET: Student/Index
    [HttpPost]
    public ActionResult Index(string groep)
    {
        var model = new SomeModel();
        model.Geslacht = new List<SelectListItem>
            {
                new SelectListItem { Text = "Female", Value = "1" },
                new SelectListItem { Text = "Male", Value = "2" }
            };
        return View(model);
    }
