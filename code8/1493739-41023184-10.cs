    public List<City> getCititesFromDatabaseByStateId(int id)
    {
        return db.Citys.Where(c => c.StateId == id).ToList();
    }
    public ActionResult Create()
    {
         var states = new SelectList(db.States.ToList(), "StateId", "Abbr");
         var citys = new SelectList(db.Citys.ToList(), "CityId", "Name");
         var zips = new SelectList(db.Zips.ToList(), "ZipId", "Code");
    
         var viewModel = new CustomerFormVM
         {
             States = states,
             Citys = citys,
             Zips = zips
         };
    
         return View(viewModel);
    }
