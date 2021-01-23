    [HttpPost]
    public ActionResult Edit(List<SiteVM> model)
    {
        if (!model.Any(x => x.IsSelected))
        {
            ModelState.AddModelError("Sites", "Please select at least one site");
        }
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        ...
    }
