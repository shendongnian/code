    public ActionResult Create()
    {
        var model = new MyViewModel();
        model.ClubList = GetClubs();
        return View(model);
    }
    public static SelectList GetClubs()
    {
        
        var club = new ClubsService().RecordView().ToList();
        var ls = new SelectList(club, "clubID", "clubID");
        return ls;
    }
