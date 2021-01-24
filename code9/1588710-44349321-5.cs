    [HttpPost]
    public IActionResult Create(Site site)
    {  // debug here are you getting parent & its child ?
    _context.Sites.Add(site);
       // for (int i = 0; i < site.LocationCount; i++)  // No need of it
       // _context.Locations.Add(new Location(site));   // No need of it
    _context.SaveChanges();
    return RedirectToAction("Details", new { Name = site.Name });
    }
