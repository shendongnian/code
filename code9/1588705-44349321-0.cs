    public class Site
    {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int LocationCount { get; set; } 
    public List<Location> Locations { get; set; } ;
    }
    public class Location
    {
    public int Id { get; set; }
    public int SiteId { get; set; }
    public Site Site { get; set; }
    public int AreaCount { get; set; } 
    public Site Site { get; set; }
    }
    [HttpPost]
    public IActionResult Create(Site site)
    {  // debug here are you getting parent & its child ?
    _context.Sites.Add(site);
       // for (int i = 0; i < site.LocationCount; i++)  // No need of it
       // _context.Locations.Add(new Location(site));   // No need of it
    _context.SaveChanges();
    return RedirectToAction("Details", new { Name = site.Name });
    }
