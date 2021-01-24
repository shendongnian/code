    public ActionResult Index(SearchModel model)
    {
        ApplicationDbContext db = new ApplicationDbContext();
        int districtNo = Convert.ToInt32(model.DistrictNo);
        IQueryable SearchResult = db.LetterInfos.Where(l => l.DistrictNo == 
            districtNo && l.State == model.State)
            .Select(s => s);
        return View();
    }
   
    
