    [HttpPost]
    public IActionResult Create(Site site)
    {  // debug here are you getting parent & its child ?
    _context.Sites.Add(site);
       // get the last added site id
          
       int? maxId=
      _context.Sites.orderbyDecending(x=>x.sideId).FirstorDefault(x=>x.siteId);// may be in this line typing mistake , you change it according to linq
        foreach(var i in site.Location) 
        {
          // in this loop traverse the child array and override the foreign key id with last added id
           i.siteId=maxId;
          _context.Locations.Add(i);
        }
       // for (int i = 0; i < site.LocationCount; i++)  // No need of it
       // _context.Locations.Add(new Location(site));   // No need of it
    _context.SaveChanges();
    return RedirectToAction("Details", new { Name = site.Name });
    }
