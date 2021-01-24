    [HttpPost]
    public IActionResult Create(Site site)
    {  // debug here are you getting parent & its child ?
    _context.Sites.Add(site);
       // get the last added site id
          
       int? maxId=
      _context.Sites.orderbyDecending(x=>x.SiteId).FirstorDefault(x=>x.SiteId);// may be in this line typing mistake , you change it according to linq
        foreach(var i in site.Location) 
        {
          // in this loop traverse the child array and override the foreign key id with last added id
           i.SiteId =maxId;
          _context.Locations.Add(i);
        }
    _context.SaveChanges();
    return RedirectToAction("Details", new { Name = site.Name });
    }
