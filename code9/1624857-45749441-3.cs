    public ActionResult Create(CarVM model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        // To get the ID's of the selected gears
        IEnumerable<int> selected = model.Gears.Where(x => x.IsSelected).Select(x => x.ID);
        // Initialize your data models, save and redirect
    }
             
        
