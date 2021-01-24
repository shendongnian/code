    public ActionResult Index()
    {                     
        var statuses = _db.Status.Select(m => new MultiSelectVm { Id = m.Id, Description = m.Description }).ToList();
        return View(new HomeVm( statuses,  _db.Assets));
    }
    
