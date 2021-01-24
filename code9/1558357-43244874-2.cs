    public ActionResult Index()
    {
        var clients = db.Clients
            .Include(p => p.Assets.Select(s => s.Address))
            .Include(p => p.Assets.Select(s => s.OccupancyRecords))
            .Include(p => p.Assets.Select(s => p.RentRecords))
            .Include(p => p.HomeAddress)
            .Include(p => p.WorkAddress)
            .ToList();
        return View(clients);
    }
