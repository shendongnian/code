    public ActionResult Index()
    {
        var clients = db.Clients
            .Include(p => p.Assets)
                .ThenInclude(p => p.Address)
            .Include(p => p.Assets)
                .ThenInclude(p => p.OccupancyRecords)
            .Include(p => p.Assets)
                .ThenInclude(p => p.RentRecords)
            .Include(p => p.HomeAddress)
            .Include(p => p.WorkAddress)
            .ToList();
        return View(clients);
    }
