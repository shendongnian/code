    public ActionResult Create()
    {
        var gears = db.Gears;
        CarVM model = new CarVM
        {
            Gears = gears.Select(x => new GearVM
            {
                ID = x.gid,
                Name = x.gname
            }).ToList()
        };
        return View(model);
    }
