    public ActionResult Index()
    {
        var systemUsers = db.SystemUsers
                            .Include(s => s.SystemUser1)
                            .Select(s => new SystemUser { //<--HERE
                                             FullName = s.FullName, 
                                             Email = s.Email, 
                                             Image = s.Image, 
                                             UpdateDate = s.UpdateDate, 
                                             UpdatedBy = s.UpdatedBy, 
                                             Id = s.Id
                                     });
        return View(systemUsers.ToList());
    }
