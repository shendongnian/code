    [HttpPost]
    public ActionResult Index(NumberSetList model) {
        if (!ModelState.IsValid) {
            return View();
        } else {
            var numbers = model.SortOrder == "Desc" ?
                model.Numbers.OrderByDescending(n => n.Value) : 
                model.Numbers.OrderBy(n => n.Value);
            model.Numbers = numbers.ToList();
            return View(model);
        }
    }
