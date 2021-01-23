    [HttpPost]
    public ActionResult SortDesc(NumberSetList model) {
        if (!ModelState.IsValid) {
            return View();
        } else {
            var numbers = model.Numbers.OrderByDescending(n => n.Value);
            model.SortOrder = "Desc";
            model.Numbers = numbers.ToList();
            return View(model);
        }
    }
