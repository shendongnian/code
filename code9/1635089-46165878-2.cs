    public ActionResult Manage(int? page, bool oldInventoryIsShown)
    {
        int pageSize = 3;
        int pageNumber = page ?? 1;
        IQueryable<Book> inventory = db.Books;
        if (!oldInventoryIsShown)
        {
            inventory = inventory.Where(x => !x.IsDisabled);
        }
        ManageViewModel model = new ManageViewModel
        {
            Inventory = inventory.ToPagedList(pageNumber, pageSize),
            OldInventoryIsShown = oldInventoryIsShown
        };
        return View(model);
    }
