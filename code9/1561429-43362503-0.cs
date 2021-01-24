    public ActionResult Index()
    {
        var clients = db.Clients.Include(c => c.OccupancyRecords) // how to get the asset name instead of the id)
            .Include(c => c.HomeAddress)
            .Include(c => c.WorkAddress);
        return View(clients.ToList());
    }
