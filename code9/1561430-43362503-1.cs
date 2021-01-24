     public ActionResult Index()
    {
        var clients = db.Clients.Include(c => c.OccupancyRecords.Select(s => new { AssetId = s.AssetId, AssetName = /* Find AssetName  By Id here */ }))  
            .Include(c => c.HomeAddress)
            .Include(c => c.WorkAddress);
        return View(clients.ToList());
    }
   
