    [HttpPost]
    public ActionResult Index(MyViewModel model)
    {
        ... process the data
    
        // populate the Profile_Id property because we are
        // redisplaying the same view which depends on it in order
        // to show the corresponding dropdown
        ViewBag.Profile_Id = new SelectList(db.PROFILE.Where(y => y.ID== myId ), "Profile_Id", "Name");
    
        return View(model);
    }
