    public ActionResult Index()
    {
        List<Site> sites = db.Sites.ToList();
        MyViewModel model = new MyViewModel();
        foreach(var site in sites)
        {
            model.DropdownItems.Add(new SelectListItem() { Text = site.Name, Value = site.ID.ToString() });
        }
        return View(model);
    }
