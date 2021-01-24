    public ActionResult Index(SearchModel model)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                int districtNo = Convert.ToInt32(model.DistrictNo);
                var SearchResult = db.LetterInfos.Where(l => l.DistrictNo == districtNo && l.State == model.State)
                             .ToList();
    
    
                return View(SearchResult);
            }
        }
